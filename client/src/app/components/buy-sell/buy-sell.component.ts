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
  template: `<div>

  </div>`
})

export class BuySellComponent implements OnInit {

  constructor(
    private buySell: BuySellService,
    private GMP: GetMyPortfoliosService,
    private BSP: BuySellToPortfolioService
  ) { }

  symbolSearch = new FormControl('');
  symbol = new FormControl('');
  qty: any;
  tickerPrice: any;
  tickerData: any;
  selected: string = 'Buy';
  portfolios: Portfolio[] = [];
  tickerSymbol: any;
  details: BuySellDetails[] = [];
  results: Results[] = [];
  portfolioID: string = '';
  buyResult: any;
  sellResult: any;

  // Dropdown box on web page options
  options: Options[] = [
    { value: 'Buy', viewValue: 'Buy' },
    { value: 'Sell', viewValue: 'Sell' },
  ];

  //TEMP DATA DELETE BEFORE FOR PRODUCTION *****
  costTotal = [{ quantity: 5, price: 10 }];
  totalPrice = 0;

  // For payment buttons
  onPayment() {

    if (!this.symbol.value) return;

    this.buySell.getTickerData(this.symbol.value).subscribe(res => {

      console.log(this.portfolioID, this.symbol.value, this.qty, res.results[0].c)
      console.log(this.selected);
      if (this.selected === 'Buy') {
        if (!this.symbol.value) return;
        this.createBuy(this.portfolioID, this.symbol.value, this.qty, res.results[0].c);
      }

      if (this.selected === 'Sell') {
        if (!this.symbol.value) return;
        this.createSell(this.portfolioID, this.symbol.value, this.qty, res.results[0].c);
      }
    })
  }// End on payment

  ngOnInit(): void {
    this.GMP.getMyPortfolios().subscribe(portArr => this.portfolios = portArr)
  };

  // Retuns the ticker data from Polygon.io
  getTickerData(tickerSymbol: any) {
    if (!tickerSymbol) return;
    this.buySell.getTickerData(tickerSymbol).subscribe(tickerData => {
      this.tickerData = (tickerData.results)
      console.log(tickerData.results)
    });
  }

  // Creates buy request to the database
  createBuy(portfolioID: string, symbol: string, qty: number, buyPrice: number): void {
    this.BSP.createBuy(portfolioID, symbol, qty, buyPrice).subscribe(br => {
      this.buyResult = br;
      console.log(br);
    });
  }

  // Creates sell request to the database
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
