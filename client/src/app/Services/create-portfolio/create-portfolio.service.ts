import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Portfolio } from 'src/app/Models/Portfolio';
import { Observable } from 'rxjs';
import { baseURL } from '../base-url';

@Injectable({
  providedIn: 'root'
})
export class CreatePortfolioService {

  constructor(private http: HttpClient) { }

  createPortfolio(name: string, originalLiquid: number, privacyLevel: number): Observable<Portfolio[]> {
    return this.http.post<Portfolio[]>(baseURL + '/create-portfolio', {portfolioID: null, name, originalLiquid, privacyLevel})
  }
}
