import { HttpClient } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { BuySellDetails, Options } from '../../Models/buy-sell/buySellOptions';
import { BuySellService } from 'src/app/services/buy-sell/buy-sell.service';
import { BuySellOptions } from '../../Models/buy-sell/buySellOptions';

@Component({
  selector: 'app-buy-sell',
  templateUrl: './buy-sell.component.html',
  styleUrls: ['./buy-sell.component.css'],
  template:`<div>

  </div>`
})
export class BuySellComponent implements OnInit {

  constructor(private http: HttpClient, private buySell: BuySellService) { }


  qty: any;
  tickerPrice: any;

  details: BuySellDetails[] = [];


  options: Options[] = [
    { value: 'Buy', viewValue: 'Buy' },
    { value: 'Buy at the open', viewValue: 'Buy at open' },
    { value: 'Buy at the close', viewValue: 'Buy at close' },
    { value: 'Set buy limit', viewValue: 'Set buy limit' },
    { value: 'Sell', viewValue: 'Sell' },
    { value: 'Sell at the open', viewValue: 'Sell at open' },
    { value: 'Sell at the close', viewValue: 'Sell at close' },
    { value: 'Set sell limit', viewValue: 'Set sell limit' }

  ];

  getQty() {
    this.qty;
  }

  costTotal = [{quantity: 5, price: 10 }];
  totalPrice = 0;

  onPayment() {
    window.alert('Your order has been submitted!');
  }

  ngOnInit(): void {
    this.calculateTotal();

    CUSTOM_ELEMENTS_SCHEMA;
  };

  calculateTotal() {
    this.costTotal.map((cost) => {
      this.totalPrice = cost.quantity * cost.price;
    });
  }
  // this.buySellService.getTickerPrice().subscribe(response => {this.tickerPrice = response;}

}
