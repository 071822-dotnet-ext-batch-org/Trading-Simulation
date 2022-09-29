import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TransactionInfo } from '../../Models/buy-sell/buySellTransactions';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class BuySellToPortfolioService {


  payments: TransactionInfo[]= [];

  /////////// NEED TO ADD WEB TOKEN!!!!//////////////
  private swaggerApi = 'https://localhost:7280';

  constructor(private http: HttpClient) { }


}
