import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UpdatePrice } from 'src/app/Models/UpdatePrice';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UpdatePriceService {

  constructor(private http: HttpClient) { }

  updatePrice(price: number, symbol: string): Observable<UpdatePrice> {
    return this.http.put<UpdatePrice>(environment.baseURL + '/update-current-price', {price: price, symbol: symbol});
  } 
}
