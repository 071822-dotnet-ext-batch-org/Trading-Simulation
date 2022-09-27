import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { callBuySellApi } from '../../Models/buy-sell/buy-sell-api-call';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class BuySellService {

  items: callBuySellApi[] = [];

  /////////// NEED TO ADD WEB TOKEN!!!!//////////////
  private lastQuote = 'https://api.polygon.io/v2/last/nbbo/AAPL?apiKey=    ';

  constructor(private http: HttpClient) { }

  getTickerPrice(): Observable<any> {
    return this.http.get<any>(this.lastQuote);
  };

}
