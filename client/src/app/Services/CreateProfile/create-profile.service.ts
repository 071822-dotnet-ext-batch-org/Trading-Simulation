import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '@auth0/auth0-angular';
import { Observable } from 'rxjs';
import { Profile } from 'src/app/Models/Profile';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CreateProfileService {
  constructor(private http: HttpClient) { }

  public createProfile( profileName:any, profileEmail:any, profilePicture:any,profilePrivacyLevel:any): Observable<Profile>{
    return this.http.post<Profile>(env.baseURL + '/create-profile', { name:profileName, email:profileEmail, picture:profilePicture, privacyLevel:profilePrivacyLevel})
  }
}
