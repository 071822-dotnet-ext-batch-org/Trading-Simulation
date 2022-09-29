import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Profile } from 'src/app/Models/Profile';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GetProfileByUserIDService {

  constructor(private http: HttpClient) { }

  getProfile(userID: string): Observable<Profile> {
    return this.http.post<Profile>(environment.baseURL + '/get-profile', { userID: userID });
  }
}
