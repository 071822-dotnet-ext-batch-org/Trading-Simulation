import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Profile } from 'src/app/Models/Profile';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UpdateProfileService {

  constructor(private http: HttpClient) { }

  public updateProfile(profileName:any, profileEmail:any, profilePicture:any, profilePrivacyLevel:any): Observable<Profile>{
    return this.http.put<Profile>(env.baseURL + '/edit-profile', { name:profileName, email:profileEmail, picture:profilePicture, privacyLevel:profilePrivacyLevel })
  }
}
