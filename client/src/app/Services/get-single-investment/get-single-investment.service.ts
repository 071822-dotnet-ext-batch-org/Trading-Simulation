import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Investment } from 'src/app/Models/Investment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GetSingleInvestmentService {

  constructor(private http: HttpClient) { }

  getSingleInvestment(portfolioId: string, symbol: string): Observable<Investment> {
    return this.http.post<Investment>(environment.baseURL + '/single-investment', {portfolioId: portfolioId, symbol: symbol})
  }
}
