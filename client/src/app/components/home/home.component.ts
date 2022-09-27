import { Component, OnInit } from '@angular/core';
import { NgModel } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CuriencyapiService } from 'src/app/service/curiencyapi.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})


export class HomeComponent  {
title = 'currencyconvert';
currjson :any =[];
base = 'USD';
cont2 = 'USD';
result : string = '1' ;

  constructor(private currency : CuriencyapiService) { }

  ngOnInit(): void {



  }

  changebase(a : string){
    this.base = a;
    console.log(this.base)
  }

  tocountry(b : string){
    this.cont2 = b;
    console.log(this.cont2)
  }

  convert(){
   // console.log(this.base)
  // console.log(this.cont2)
    this.currency.getcurrencydata(this.base)
    .subscribe(data =>{
     // console.log(data)
      this.currjson = JSON.stringify(data);
      this.currjson = JSON.parse(this.currjson);
      //console.log(this.currjson);

      if(this.cont2 == 'USD'){
        this.result = this.currjson.rates.USD
      }

      

      if(this.cont2 == 'INR'){
        this.result = this.currjson.rates.INR
      }

      if(this.cont2 == 'EUR'){
        this.result = this.currjson.rates.EUR 
      }

      if(this.cont2 == 'KWD'){
        this.result = this.currjson.rates.KWD
      }
      if(this.cont2 == 'BHD'){
        this.result = this.currjson.rates.BHD
      }

    } )

  }

}
