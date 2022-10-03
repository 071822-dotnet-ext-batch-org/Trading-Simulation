import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Portfolio } from 'src/app/Models/Portfolio';
import { Observable } from 'rxjs';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CreatePortfolioService {

  constructor(private http: HttpClient) { }

  createPortfolio(name: string, originalLiquid: number, privacyLevel: number): Observable<Portfolio> {
    return this.http.post<Portfolio>(env.baseURL + '/create-portfolio', {portfolioID: null, name, originalLiquid, privacyLevel})
  }
}
