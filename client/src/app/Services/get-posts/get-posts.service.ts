import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Post } from 'src/app/Models/Posts';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GetPostsService {

  constructor(private http: HttpClient) { }

 public getAllPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(environment.baseURL + '/get-all-post');
  }
}
