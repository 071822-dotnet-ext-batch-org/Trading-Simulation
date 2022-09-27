import { Injectable } from '@angular/core';
import {HttpClient}  from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CuriencyapiService {

  constructor(private http:HttpClient) { }

  getcurrencydata(country1:string){
    let url = 'https://api.exchangerate.host/latest?base=' + country1
    return this.http.get(url);
  }
}
