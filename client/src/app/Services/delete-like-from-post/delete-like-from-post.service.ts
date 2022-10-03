import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DeleteLikeFromPostService {

  constructor(private http: HttpClient) { }

  deleteLike(postId: string): Observable<number> {
    return this.http.delete<number>(environment.baseURL + '/remove-like-on-post', { body: { postId: postId } });
  }
}
