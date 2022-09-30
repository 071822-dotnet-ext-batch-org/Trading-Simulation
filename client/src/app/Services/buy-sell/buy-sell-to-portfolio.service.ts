import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Buy, Sell } from 'src/app/Models/buy-sell/buySellApiCall';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BuySellToPortfolioService {

  buy: any; //For createBuy
  sell: any; //For createSell

  constructor(private http: HttpClient) { }

  // Http Post method that sends a newly created buy order to the database
  createBuy(portfolioID: string, symbol: string, qty: number, buyPrice: number): Observable<Buy> {
    return this.http.post<Buy>(environment.baseURL + '/create-buy', {
      portfolioId: portfolioID,
      symbol: symbol,
      currentPrice: buyPrice,
      amountBought: qty,
      priceBought: buyPrice,
    });
  }

  // Http Post method that sends a newly created sell order to the database
  createSell(portfolioID: String, symbol: String, amountSold: Number, priceSold: number): Observable<Sell> {
    return this.http.post<Sell>(environment.baseURL + '/create-sell', {
      fk_portfolioID: portfolioID,
      symbol: symbol,
      amountSold: amountSold,
      priceSold: priceSold
    })
  };

}
