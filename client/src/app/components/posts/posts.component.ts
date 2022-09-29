import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/Models/Posts';
import { GetPostsService } from 'src/app/Services/get-posts/get-posts.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  loadingPosts: boolean = false;
  posts: Post[] = [];

  constructor(
    private GPS: GetPostsService,
 
  ) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts(): void {
    this.loadingPosts = true;
    this.GPS.getAllPosts().subscribe(allPosts => {
      this.posts = allPosts;
      this.loadingPosts = false;
    })
  }
}
