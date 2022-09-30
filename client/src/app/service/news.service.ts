import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { News } from 'src/Models/News';

@Injectable({
  providedIn: 'root'
})
export class NewsService { 
  
  constructor(private http:HttpClient) {}
    private Nurl = "https://api.polygon.io/v2/reference/news?apiKey=fDmFrsl9AIqWWbysyVWVMTi9dosuDNpF";

    private NewsApi = "https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=57f46663b22c4d878e3b602457bb831f";


  public getNews():Observable<any>{
    return this.http.get<any>(this.Nurl)
  }

  public getAllNews():Observable<any>{
    return this.http.get<any>(this.NewsApi)
  }
  
  }

