import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Buy, Sell } from 'src/app/Models/buy-sell/buySellApiCall';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BuySellToPortfolioService {

  buy: any; // For createBuy below
  sell: any; // For createSell below

  constructor(private http: HttpClient) { }

   // Http Post method that sends a newly created buy order to our database. On the buy/sell page it will take in the portfolioID selected,
  //  ticker symbol, currentPrice(taken from Polygon.io api), the amountBought(qty), and for priceBought(taken from Polygon.io api) which will be later multiple qty by price.
  createBuy(portfolioID: string, symbol: string, qty: number, buyPrice: number): Observable<Buy> {
    return this.http.post<Buy>(environment.baseURL + '/create-buy', {
      portfolioId: portfolioID,
      symbol: symbol.toUpperCase(),
      currentPrice: buyPrice,
      amountBought: qty,
      priceBought: buyPrice,
    });
  }

  // Http Post method that sends a newly created sell order to our database. On the buy/sell page it will take in the portfolioID selected,
  // the ticker symbol, the amountSold(quantity), and for priceSold(taken from Polygon.io api).
  createSell(portfolioID: String, symbol: String, amountSold: Number, priceSold: number): Observable<Sell> {
    return this.http.post<Sell>(environment.baseURL + '/create-sell', {
      fk_portfolioID: portfolioID,
      symbol: symbol.toUpperCase(),
      amountSold: amountSold,
      priceSold: priceSold
    })
  };

}
