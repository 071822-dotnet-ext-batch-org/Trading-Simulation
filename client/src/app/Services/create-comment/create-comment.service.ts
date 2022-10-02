import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CreateCommentService {

  constructor(private http: HttpClient) { }

  createComment(content: string): Observable<Comment[]> {
    return this.http.post<Comment[]>(env.baseURL + '/add-comment', {portfolioID: null, content})
  }
}
