import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { News } from 'src/app/Models/News';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewsService { 
  
  constructor(private http:HttpClient) {}
    private Nurl = "https://api.polygon.io/v2/reference/news?apiKey=" + environment.polygonApiKey;


  public getNews():Observable<any>{
    return this.http.get<any>(this.Nurl)
  }
  
  }

