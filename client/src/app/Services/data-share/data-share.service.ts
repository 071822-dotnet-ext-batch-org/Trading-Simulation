import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Portfolio } from 'src/app/Models/Portfolio';

@Injectable({
  providedIn: 'root'
})
export class DataShareService {

  constructor() { }

  private portfolios: Subject<Portfolio[]> = new Subject<Portfolio[]>();

  updatePortfolios(ports: Portfolio[]){
    this.portfolios.next(ports);
  }

  getUpdatedPortfolios(): Observable<Portfolio[]> {
    return this.portfolios.asObservable();
  }
}
