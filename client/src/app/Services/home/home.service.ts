import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  //Beverly - method to return the number of users
  public getNumberOfUsers(): Observable<number> {
    return this.http.get<number>(environment.baseURL + '/number-of-users');
  }
  //Beverly - method to return the number of posts
  public getNumberOfPosts(): Observable<number> {
    return this.http.get<number>(environment.baseURL + '/number-of-posts');
  }
  //Beverly - method to return the number of buys
  public getNumberOfBuys(): Observable<number> {
    return this.http.get<number>(environment.baseURL + '/number-of-buys');
  }
  //Beverly - method to return the number of sells
  public getNumberOfSells(): Observable<number> {
    return this.http.get<number>(environment.baseURL + '/number-of-sells');
  }
}