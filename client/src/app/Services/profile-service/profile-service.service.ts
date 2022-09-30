import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Profile } from 'src/app/Models/Profile';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProfileServiceService {

  constructor(private http: HttpClient) { }

  public getProfiles(): Observable<Profile>{
    return this.http.get<Profile>(env.baseURL + '/my-profile'); //not sure aabout the path:
  }
}
