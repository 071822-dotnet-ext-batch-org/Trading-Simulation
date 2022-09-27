import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Portfolio } from 'src/app/Models/Portfolio';
import { Observable } from 'rxjs';
import { baseURL } from '../base-url';

@Injectable({
  providedIn: 'root'
})
export class GetMyPortfoliosService {

  constructor(private http: HttpClient) { }

  getMyPortfolios(): Observable<Portfolio[]> {
    return this.http.get<Portfolio[]>(baseURL + '/my-portfolios')
  }
}
