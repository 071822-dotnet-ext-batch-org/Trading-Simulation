import { Component, Input, OnInit } from '@angular/core';
import { Comment } from 'src/app/Models/Comment';
import { ProfileComponent } from '../profile/profile.component';
import { GetProfileByUserIDService } from 'src/app/Services/get-profile-by-user-id/get-profile-by-user-id.service'; 
import { Profile } from 'src/app/Models/Profile';

@Component({
  selector: 'app-single-comment',
  templateUrl: './single-comment.component.html',
  styleUrls: ['./single-comment.component.css']
})
export class SingleCommentComponent implements OnInit{
  // @Input() comment!: Comment;
  

  constructor(
    
  ) { }

  ngOnInit(): void {
  }

}
