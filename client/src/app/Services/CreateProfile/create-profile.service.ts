import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '@auth0/auth0-angular';
import { Observable } from 'rxjs';
import { Profile } from 'src/app/Models/Profile';
import { baseURL } from '../base-url';

@Injectable({
  providedIn: 'root'
})
export class CreateProfileService {
  constructor(private http: HttpClient) { }

  public createProfile( profilePicture: string, profileName: string, profileEmail: string,profilePrivacyLevel:number): Observable<User>{
    return this.http.post<User>(baseURL + 'CreateProfileAsync/Profiles.json', { CreateProfileService })
  }
}
