import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Profile } from 'src/app/Models/Profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileServiceService {

  constructor(private http: HttpClient) { }

  private rootUrl = 'https://localhost:7280/';

  public getProfiles(): Observable<Profile[]>{
    return this.http.get<Profile[]>(this.rootUrl + '/api/Yoink/GetProfileByUserIDAsync'); //not sure aabout the path:
  }
}
