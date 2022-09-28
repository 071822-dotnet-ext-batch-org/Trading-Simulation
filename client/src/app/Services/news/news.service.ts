import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { News } from 'src/app/Models/News';

@Injectable({
  providedIn: 'root'
})
export class NewsService { 
  
  constructor(private http:HttpClient) {}
    private Nurl = "https://api.polygon.io/v2/reference/news?apiKey=fDmFrsl9AIqWWbysyVWVMTi9dosuDNpF";


  public getNews():Observable<any>{
    return this.http.get<any>(this.Nurl)
  }
  }

