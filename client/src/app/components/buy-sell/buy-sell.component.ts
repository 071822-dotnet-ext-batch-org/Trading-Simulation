import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Options } from './buySellOptions';


@Component({
  selector: 'app-buy-sell',
  templateUrl: './buy-sell.component.html',
  styleUrls: ['./buy-sell.component.css']
})
export class BuySellComponent implements OnInit {

  constructor() { }

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

  ngOnInit(): void {
    CUSTOM_ELEMENTS_SCHEMA
  }

}
