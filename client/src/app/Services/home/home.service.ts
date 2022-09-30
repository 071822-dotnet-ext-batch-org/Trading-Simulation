import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  public getNumberOfUsers(): Observable<number> {
    return this.http.get<number>(environment.baseURL + '/number-of-users');
  }

  public getNumberOfPosts(): Observable<number> {
    return this.http.get<number>(environment.baseURL + '/number-of-posts');
  }

  public getNumberOfBuys(): Observable<number> {
    return this.http.get<number>(environment.baseURL + '/number-of-buys');
  }

  public getNumberOfSells(): Observable<number> {
    return this.http.get<number>(environment.baseURL + '/number-of-sells');
  }
}