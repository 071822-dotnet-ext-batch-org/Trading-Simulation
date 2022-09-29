import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TransactionInfo } from '../../Models/buy-sell/buySellTransactions';
import { Observable } from 'rxjs';
import { Buy } from 'src/app/Models/buy-sell/buySellApiCall';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class BuySellToPortfolioService {

  buy: any;
  
  
  constructor(private http: HttpClient) { }

  createBuy(portfolioID: string, symbol: string, qty: number, buyPrice: number): Observable<Buy> {
    return this.http.post<Buy>(environment.baseURL + '/create-buy', {
      fk_PortfolioID: portfolioID,
      symbol: symbol,
      currentPrice: buyPrice,
      amountBought: qty,
      priceBought: buyPrice,
    });
  }
}
