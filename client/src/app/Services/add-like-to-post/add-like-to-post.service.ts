import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AddLikeToPostService {

  constructor(private http: HttpClient) { }

  addLike(postId: string): Observable<number> {
    return this.http.post<number>(environment.baseURL + '/add-like-on-post', {postId: postId});
  }
}
