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
  template:`<div>

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


  options: Options[] = [
    { value: 'Buy', viewValue: 'Buy' },
    // { value: 'Buy at the open', viewValue: 'Buy at open' },
    // { value: 'Buy at the close', viewValue: 'Buy at close' },
    // { value: 'Set buy limit', viewValue: 'Set buy limit' },
    { value: 'Sell', viewValue: 'Sell' },
    // { value: 'Sell at the open', viewValue: 'Sell at open' },
    // { value: 'Sell at the close', viewValue: 'Sell at close' },
    // { value: 'Set sell limit', viewValue: 'Set sell limit' }
  ];


  costTotal = [{quantity: 5, price: 10 }];
  totalPrice = 0;

  onPayment() {
    
    if(!this.symbol.value) return;

    this.buySell.getTickerData(this.symbol.value).subscribe(res => {

      console.log(this.portfolioID, this.symbol.value, this.qty, res.results[0].c)
      if(this.selected === 'Buy'){
        if(!this.symbol.value) return;
        this.createBuy(this.portfolioID, this.symbol.value, this.qty, res.results[0].c);
      }

      if(this.selected === 'Sell'){
        if(!this.symbol.value) return;
        this.createSell(this.portfolioID, this.symbol.value, this.qty, res.results[0].c);
      }
    })
  }

  ngOnInit(): void {
    this.GMP.getMyPortfolios().subscribe(portArr => this.portfolios=portArr)
  };

  calculateTotal() {
    this.costTotal.map((cost) => {
      this.totalPrice = cost.quantity * cost.price;
    });
  }

  getTickerData(tickerSymbol: any) {
    
    if (!tickerSymbol) return;
    this.buySell.getTickerData(tickerSymbol).subscribe(tickerData => {
      this.tickerData = (tickerData.results)
      console.log(tickerData.results)
    });
  }

  createBuy(portfolioID: string, symbol: string, qty: number, buyPrice: number): void{
    this.BSP.createBuy(portfolioID, symbol, qty, buyPrice).subscribe(br => {
      this.buyResult = br;
    });
  }

  createSell(portfolioID: string, symbol: string, qty: number, sellPrice: number): void{

  }
}
