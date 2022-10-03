import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Post } from 'src/app/Models/Posts';
import { Profile } from 'src/app/Models/Profile';
import { CreatePostService } from 'src/app/Services/create-post/create-post.service';

import { GetPostsService } from 'src/app/Services/get-posts/get-posts.service';
import { ProfileServiceService } from 'src/app/Services/profile-service/profile-service.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  loadingPosts: boolean = false;
  posts: Post[] = [];
  myProfile: Profile = {
    profileID: '',
    picture: '',
    name: '',
    email: '',
    privacyLevel: 0
  }

  postText = new FormControl('');

  constructor(
    private GPS: GetPostsService,
    private PS: ProfileServiceService,
    private CP: CreatePostService
  ) { }

  ngOnInit(): void {
    this.getPosts();
    this.getMyProfile();
  }

  getPosts(): void {
    this.loadingPosts = true;

    this.GPS.getAllPosts().subscribe(allPosts => {
      this.posts = allPosts;
      this.loadingPosts = false;
    });
  }

  createPost(): void {
    if (this.postText.value != null){
      this.CP.createPost(this.postText.value, 0).subscribe(newPost => {
        this.posts.unshift(newPost);
        this.postText.reset();
      })
    }
  }

  getMyProfile(): void {
    this.PS.getProfiles().subscribe(prof => {
      this.myProfile = prof;
    })
  }
}
