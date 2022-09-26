import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TransactionInfo } from '../../Models/buy-sell/buySellTransactions';


@Injectable({
  providedIn: 'root'
})
export class BuySellToPortfolioService {


  payments: TransactionInfo[]= [];

  /////////// NEED TO ADD WEB TOKEN!!!!//////////////
  private urlApi = 'https://api.polygon.io/v2/aggs/ticker/AAPL/range/1/day/2020-06-01/2020-06-17?apiKey=______KEY_GOES_HERE_____';

  constructor(private http: HttpClient) { }


}
