import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class BuySellService {

  // The URL that connects to the Polygon.io "Previous Close information" api. It is broken in half so that
  // the user can eventually insert the ticker symbol. The polygonApiKey is placed in the environments folder
  // that will not be pushed to Github
  private lastQuote = 'https://api.polygon.io/v2/aggs/ticker/';
  private lastQuoteKey = '/prev?adjusted=true&apiKey=' + environment.polygonApiKey;

  constructor(private http: HttpClient) { }

  // Gets the ticker data from Polygon.io. Needs to pass 1-5 letters (limited to 5 in the buy-sell.component.html)
  // as the "tickerSymbol" which is inserted into the connection string above to tell Polygon.io which companies
  // information the user wants to see.
  public getTickerData(tickerSymbol: string): Observable<any> {
    console.log(this.lastQuote + tickerSymbol + this.lastQuoteKey);
    return this.http.get<any>(this.lastQuote + tickerSymbol.toUpperCase() + this.lastQuoteKey);
  }

}
