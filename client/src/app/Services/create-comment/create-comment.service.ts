import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateCommentModel } from 'src/app/Models/CreateCommentModel';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CreateCommentService {

  constructor(private http: HttpClient) { }

  createComment(postId: string, content: string): Observable<boolean> {
    return this.http.post<boolean>(env.baseURL + '/add-comment', {postId: postId, content: content})
  }
}
