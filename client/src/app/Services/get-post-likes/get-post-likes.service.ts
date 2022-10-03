import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GetPostLikesService {

  constructor(private http: HttpClient) { }

  getPostLikes(): Observable<string[]> {
    return this.http.get<string[]>(environment.baseURL + '/get-post-likes');
  }
}
