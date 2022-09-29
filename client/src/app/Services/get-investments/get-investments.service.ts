import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Investment } from 'src/app/Models/Investment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GetInvestmentsService {

  constructor(private http: HttpClient) { }

  getInvestments(portfolioID: string): Observable<Investment[]> {
    return this.http.post<Investment[]>(environment.baseURL + '/all-investments', { portfolioID: portfolioID })
  }
}
