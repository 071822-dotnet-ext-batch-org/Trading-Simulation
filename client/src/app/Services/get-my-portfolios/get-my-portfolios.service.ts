import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Portfolio } from 'src/app/Models/Portfolio';
import { Observable } from 'rxjs';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GetMyPortfoliosService {

  constructor(private http: HttpClient) { }

  getMyPortfolios(): Observable<Portfolio[]> {
    return this.http.get<Portfolio[]>(env.baseURL + '/my-portfolios')
  }
}
