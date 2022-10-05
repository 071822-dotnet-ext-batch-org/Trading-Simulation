import { Component, OnInit } from '@angular/core';
import { Options } from '../../Models/buy-sell/buySellOptions';
import { BuySellService } from 'src/app/Services/buy-sell/buy-sell.service';
import { Results } from 'src/app/Models/buy-sell/polygonResults';
import { FormControl } from '@angular/forms';
import { GetMyPortfoliosService } from 'src/app/Services/get-my-portfolios/get-my-portfolios.service';
import { Portfolio } from 'src/app/Models/Portfolio';
import { BuySellToPortfolioService } from 'src/app/Services/buy-sell/buy-sell-to-portfolio.service';
import { BuyDto } from 'src/app/Models/buy-sell/buySellApiCall';
import { GetSingleInvestmentService } from 'src/app/Services/get-single-investment/get-single-investment.service';

@Component({
  selector: 'app-buy-sell',
  templateUrl: './buy-sell.component.html',
  styleUrls: ['./buy-sell.component.css'],
})

export class BuySellComponent implements OnInit {

  // Creates instances from services located in the Services/buy-sell folder
  constructor(
    private buySell: BuySellService,
    private GMP: GetMyPortfoliosService,
    private BSP: BuySellToPortfolioService,
    private GSI: GetSingleInvestmentService
  ) { }

  title = 'Buy and Sell'; // Page title
  symbolSearch = new FormControl(''); // Used in html search ln: 58
  symbol = new FormControl(''); // Used in onPayment, createBuy and createSell below
  qty: any; // Used in onPayment, createBuy and createSell below
  tickerData: any; // Used in getTickerData
  selected: string = 'Buy'; // Used in onPayment
  portfolios: Portfolio[] = []; // Used in ngOnInit to get Portfolio
  tickerSymbol: any; // Used in getTickerData
  results: Results[] = []; // Used in getTickerData and onPayment
  portfolioID: string = ''; // Used in onPayment, createBuy, and createSell below
  buyResult: any; // Used in createBuy below
  sellResult: any; // Used in createSell below
  totalPrice: number = 0; // Used in the calculateTotal method
  errorMessage: string = ''; // Used in onPayments
  invQty: number = 0; // Used in onPayments
  txLoading: boolean = false; // Used in onPayments
  success: string = ''; // Used in OnPayments


  // What is shown in the dropdown box on web page options.
  options: Options[] = [
    { value: 'Buy', viewValue: 'Buy' },
    { value: 'Sell', viewValue: 'Sell' },
  ];

  selectedOption = new FormControl(this.options[0]); // For testing file
  public onBuy(){
    console.log(this.selectedOption.value?.value)
  };

  // This method uses the getTickerData() method and conencts to the Polygon.io api after which,
  // if the user choses 'Buy' in the drop down box, it will run the createBuy() method which sends the data
  // transfer object to our database once all required fields are filled. If the uese choses the
  // sell option then it will chose the createSell() method and send a data transfer object to
  // our database and removes the order from the database.
  public onPayment() {
    this.success = '';
    this.txLoading = true;

    if (!this.symbol.value) return;

    this.buySell.getTickerData(this.symbol.value).subscribe(res => {

      console.log(this.portfolioID, this.symbol.value, this.qty, res.results[0].c)
      console.log(this.selected);

      const currentPort = this.portfolios.find(p => p.portfolioID === this.portfolioID);

      if (currentPort){

        // Buy condition
        if (this.selected === 'Buy') {

          if (!this.symbol.value) return;

          if (this.qty * res.results[0].c > currentPort.liquid) {
            this.errorMessage = 'Cannot make purchase - not enough available cash';
            this.txLoading = false;
            return;
          }

          this.createBuy(this.portfolioID, this.symbol.value, this.qty, res.results[0].c);
        }

        // Sell condition
        if (this.selected === 'Sell') {

          if (!this.symbol.value) return;
          this.GSI.getSingleInvestment(this.portfolioID, this.symbol.value).subscribe(inv => {

            this.invQty = inv.currentAmount;
            if (inv.currentAmount < this.qty){
              this.errorMessage = 'Cannot sell stock - quantity held not enough';
              this.txLoading = false;
              return;
            }

            if (!this.symbol.value) return;
            this.createSell(this.portfolioID, this.symbol.value, this.qty, res.results[0].c);
          });

        }
      }
    })
  }// End on payment

  ngOnInit(): void {
    this.GMP.getMyPortfolios().subscribe(portArr => this.portfolios = portArr);
    this.calculateTotal(this.tickerSymbol, this.qty);
  };

  // Retuns the ticker data from Polygon.io after the user enters information into the search bar.
  public getTickerData(tickerSymbol: any) {
    if (!tickerSymbol) return;
    this.buySell.getTickerData(tickerSymbol).subscribe(tickerData => {
      this.tickerData = (tickerData.results);
      console.log(tickerData.results);
    });
  }

  // Creates buy request using the createBuy from the services and sends data transfer object
  // with the required fields to out database.
  public createBuy(portfolioID: string, symbol: string, qty: number, buyPrice: number): void {
    this.BSP.createBuy(portfolioID, symbol, qty, buyPrice).subscribe(br => {
      this.buyResult = br;
      this.success = 'Transaction completed';
      this.txLoading = false;
      console.log(br);
    });
  }

  // Creates sell request using the createBuy from the services and sends data transfer object
  // with the required fields to out database.
  public createSell(portfolioID: string, symbol: string, qty: number, sellPrice: number): void {
    this.BSP.createSell(portfolioID, symbol, qty, sellPrice).subscribe(sr => {
      this.sellResult = sr
      this.success = 'Transaction completed';
      this.txLoading = false;
    })
  }

  // This method takes two parameters and after confirming the ticker through the getTickerData method
  // in the Polygon.io api, it will return in the "results[0]" the first index which is the stock
  // price. Then that will be multiplied by the qty that the users enters in the quantity box on the order page.
  public calculateTotal(tickerSymbol: any, qty: number) {
    if (!tickerSymbol) return;
    console.log(tickerSymbol)
    this.buySell.getTickerData(tickerSymbol).subscribe(tickerData => {
      console.log(tickerData)
      this.tickerData = (tickerData.results[0])
      console.log(tickerData.results)
      return this.totalPrice = qty * this.tickerData.c;
    });

  };

  // Renturns form to cleared status after order/cancel
  resetForms(): void {
    this.symbol.reset();
    this.qty = 0;
    this.selected = 'Buy';
  }

}//End BuySellComponent
