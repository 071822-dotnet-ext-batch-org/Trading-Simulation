import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Profile } from 'src/app/Models/Profile';
import { baseURL } from '../base-url';

@Injectable({
  providedIn: 'root'
})
export class ProfileServiceService {

  constructor(private http: HttpClient) { }

  public getProfiles(): Observable<Profile[]>{
    return this.http.get<Profile[]>(baseURL + '/GetProfileByUserIDAsync'); //not sure aabout the path:
  }
}
