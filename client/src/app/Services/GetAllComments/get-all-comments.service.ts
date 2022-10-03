import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GetAllCommentsService {

  constructor(private http: HttpClient) { }
 
    getAllComments(): Observable<Comment[]> {
      return this.http.get<Comment[]>(env.baseURL + '/get-all-comment')
    }
}
