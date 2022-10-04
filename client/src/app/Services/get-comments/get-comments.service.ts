import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Comment } from 'src/app/Models/Comment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GetCommentsService {

  constructor(private http: HttpClient) { }

  getAllComments(): Observable<Comment[]> {
    return this.http.get<Comment[]>(environment.baseURL + '/get-all-comment', )
  }
}
