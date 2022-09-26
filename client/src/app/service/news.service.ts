import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { News } from 'src/Models/News';

@Injectable({
  providedIn: 'root'
})
export class NewsService { 
  
  constructor(private http:HttpClient) {}
    private Nurl = "https://api.marketaux.com/v1/news/all?symbols=TSLA%2CAMZN%2CMSFT&filter_entities=true&language=en&api_token=6CJ3TxOf4jYZhIgzjOaZxAK4GLC8Hlpxjckp5kbr";


  public getNewsData():Observable<any>{
    return this.http.get<any>(this.Nurl)
  }
  
  }

