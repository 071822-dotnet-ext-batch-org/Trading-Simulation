import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Profile } from 'src/app/Models/Profile';
import { baseURL } from '../base-url';

@Injectable({
  providedIn: 'root'
})
export class UpdateProfileService {

  constructor(private http: HttpClient) { }

  public updateProfile( profilePrivacyLevel:number): Observable<Profile>{
    return this.http.post<Profile>(baseURL + '/EditProfileAsync', { profilePrivacyLevel })
  }
}
