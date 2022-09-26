import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { callBuySellApi } from '../components/buy-sell/buy-sell-api-call';


@Injectable({
  providedIn: 'root'
})
export class BuySellService {

  items: callBuySellApi[] = [];

  /////////// NEED TO ADD WEB TOKEN!!!!//////////////
  private tickerApi = 'https://api.marketaux.com/v1/news/all?symbols=TSLA%2CAMZN%2CMSFT&filter_entities=true&language=en&api_token=!!!!!!TOKEN_GOES_HERE!!!!!!!!';

  constructor(private http: HttpClient) { }

  getTickerPrice() {
    return this.items
  }
}
