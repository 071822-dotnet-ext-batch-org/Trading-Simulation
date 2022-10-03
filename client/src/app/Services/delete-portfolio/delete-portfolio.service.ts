import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DeletePortfolioService {

  constructor(private http: HttpClient) { }
  

  deletePortfolio(portfolioID: string): Observable<boolean> {
    return this.http.delete<boolean>(environment.baseURL + '/delete-portfolio', { body: { portfolioID: portfolioID } })
  }
}
