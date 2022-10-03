import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Post } from 'src/app/Models/Posts';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CreatePostService {

  constructor(private http: HttpClient) { }

  createPost(content: string, privacyLevel: number): Observable<Post> {
    return this.http.post<Post>(environment.baseURL + '/create-post', {content: content, privacyLevel: privacyLevel})
  }
}
