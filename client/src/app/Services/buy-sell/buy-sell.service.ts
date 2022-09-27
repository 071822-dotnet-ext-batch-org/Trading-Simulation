import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { callBuySellApi } from '../../Models/buy-sell/buySellApiCall';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class BuySellService {

  items: callBuySellApi[] = [];

  /////////// NEED TO ADD WEB TOKEN!!!!//////////////
  private lastQuote = 'https://api.polygon.io/v2/aggs/ticker/';
  private lastQuoteKey = '/prev?adjusted=true&apiKey=Z1iQvUg4p15SM0xMbsMxVAJ_d1dZlgd4';

  constructor(private http: HttpClient) { }

  public getTickerData(tickerSymbol: string): Observable<any> {
    return this.http.get<any>(this.lastQuote + tickerSymbol + this.lastQuoteKey);
  }
}
