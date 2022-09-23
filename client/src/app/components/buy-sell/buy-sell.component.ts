import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { GoogleChartsModule } from 'angular-google-charts';


@Component({
  selector: 'app-buy-sell',
  templateUrl: './buy-sell.component.html',
  styleUrls: ['./buy-sell.component.css']
})
export class BuySellComponent implements OnInit {

  constructor() { }


  ngOnInit(): void {
    CUSTOM_ELEMENTS_SCHEMA
  }

}
