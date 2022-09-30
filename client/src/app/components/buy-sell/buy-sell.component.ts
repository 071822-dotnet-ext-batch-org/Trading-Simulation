import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { BuySellDetails, Options } from '../../Models/buy-sell/buySellOptions';
import { BuySellService } from 'src/app/Services/buy-sell/buy-sell.service';
import { Results } from 'src/app/Models/buy-sell/polygonResults';
import { FormControl } from '@angular/forms';
import { GetMyPortfoliosService } from 'src/app/Services/get-my-portfolios/get-my-portfolios.service';
import { Portfolio } from 'src/app/Models/Portfolio';
import { BuySellToPortfolioService } from 'src/app/Services/buy-sell/buy-sell-to-portfolio.service';

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
    private BSP: BuySellToPortfolioService
  ) { }

  symbolSearch = new FormControl(''); // Used in html search ln: 58
  symbol = new FormControl(''); // Used in onPayment, createBuy and createSell below
  qty: any; // Used in onPayment, createBuy and createSell below
  // tickerPrice: any;
  tickerData: any; // Used in getTickerData
  selected: string = 'Buy'; // Used in onPayment
  portfolios: Portfolio[] = [];
  tickerSymbol: any; // Used in getTickerData
  // details: BuySellDetails[] = [];
  results: Results[] = []; // Used in getTickerData and onPayment
  portfolioID: string = ''; // Used in onPayment, createBuy, and createSell below
  buyResult: any; // Used in createBuy below
  sellResult: any; // Used in createSell below

  // What is shown in the dropdown box on web page options.
  options: Options[] = [
    { value: 'Buy', viewValue: 'Buy' },
    { value: 'Sell', viewValue: 'Sell' },
  ];

  //TEMP DATA DELETE BEFORE FOR PRODUCTION *****
  totalPrice = 0;

  // This method uses the getTickerData() method and conencts to the Polygon.io api after which,
  // if the user choses 'Buy' in the drop down box, it will run the createBuy() method which sends the data
  // transfer object to our database once all required fields are filled. If the uese choses the
  // sell option then it will chose the createSell() method and send a data transfer object to
  // our database and removes the order from the database.
  onPayment() {

    if (!this.symbol.value) return;

    this.buySell.getTickerData(this.symbol.value).subscribe(res => {

      console.log(this.portfolioID, this.symbol.value, this.qty, res.results[0].c)
      console.log(this.selected);

      // Buy condition
      if (this.selected === 'Buy') {
        if (!this.symbol.value) return;
        this.createBuy(this.portfolioID, this.symbol.value, this.qty, res.results[0].c);
      }

      // Sell condition
      if (this.selected === 'Sell') {
        if (!this.symbol.value) return;
        this.createSell(this.portfolioID, this.symbol.value, this.qty, res.results[0].c);
      }
    })
  }// End on payment

  ngOnInit(): void {
    this.GMP.getMyPortfolios().subscribe(portArr => this.portfolios = portArr)
  };

  // Retuns the ticker data from Polygon.io after the user enters information into the search bar.
  getTickerData(tickerSymbol: any) {
    if (!tickerSymbol) return;
    this.buySell.getTickerData(tickerSymbol).subscribe(tickerData => {
      this.tickerData = (tickerData.results)
      console.log(tickerData.results)
    });
  }

  // Creates buy request using the createBuy from the services and sends data transfer object
  // with the required fields to out database.
  createBuy(portfolioID: string, symbol: string, qty: number, buyPrice: number): void {
    this.BSP.createBuy(portfolioID, symbol, qty, buyPrice).subscribe(br => {
      this.buyResult = br;
      console.log(br);
    });
  }

  // Creates sell request using the createBuy from the services and sends data transfer object
  // with the required fields to out database.
  createSell(portfolioID: string, symbol: string, qty: number, sellPrice: number): void {
    this.BSP.createSell(portfolioID, symbol, qty, sellPrice).subscribe(sr => {
      this.sellResult = sr
    })
  }

  //////////// TODO /////////////
  public calculateTotal(qty: number, buyPrice: number) {
    return this.totalPrice = qty * buyPrice;
  };


}//End BuySellComponent
