import { Component, OnInit } from '@angular/core';
import { NgModel } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CuriencyapiService } from 'src/app/Services/currency-api/curiencyapi.service';
import { HomeService } from 'src/app/Services/home/home.service';
import { AuthService } from '@auth0/auth0-angular';
import { AuthModule } from '@auth0/auth0-angular';
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
numOfUsers: number = 0;
numOfPosts: number = 0;
numOfBuys: number = 0;
numOfSells: number = 0;

  constructor(private currency : CuriencyapiService, private homeService: HomeService) { }
 
  ngOnInit(): void {
    this.getNumberOfUsers()//Beverly - calls number of users method when home component is intialized
    this.getNumberOfPosts()//Beverly - calls number of posts method when home componenet is initialized
    this.getNumberOfSells()//Beverly - calls number of sells methos when home component is intialized
    this.getNumberOfBuys()//Beverly - calls number of buys method when home component is intitalized
  }
  //Beverly - method for number of users for home page card located at bottom of page in the "Check us out section"
  getNumberOfUsers():void{
    this.homeService.getNumberOfUsers()
    .subscribe(numberOfUsers => {
      this.numOfUsers = numberOfUsers
      console.log(numberOfUsers)
    });
  }
  //Beverly - method for number of posts for home page card located at the bottom of page in the "Check us out section"
  getNumberOfPosts():void{
    this.homeService.getNumberOfPosts()
    .subscribe(numberOfPosts => {
      this.numOfPosts = numberOfPosts
      console.log(numberOfPosts)
    });
  }
  //Beverly - method for number of buys for the home page card located at the bottom of page in the "Check us out section"
  getNumberOfBuys():void{
    this.homeService.getNumberOfBuys()
    .subscribe(numberOfBuys => {
      this.numOfBuys = numberOfBuys
      console.log(numberOfBuys)
    });
  }
  //Beverly - method for number of sells for the home page card at the bottom of page in the "Check us out section"
  getNumberOfSells():void{
    this.homeService.getNumberOfSells()
    .subscribe(numberOfSells => {
      this.numOfSells = numberOfSells
      console.log(numberOfSells)
    });
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
    this.currency.getcurrencydata(this.base)
    .subscribe(data =>{
      this.currjson = JSON.stringify(data);
      this.currjson = JSON.parse(this.currjson);

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
    })
  }
}
