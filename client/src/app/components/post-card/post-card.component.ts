import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/Models/Posts';
import { GetProfileByUserIDService } from 'src/app/Services/get-profile-by-user-id/get-profile-by-user-id.service';
import { MatDialog } from '@angular/material/dialog'; //coment box (sam)
import { CommentsComponent } from '../comment/comments.component';
import { AddLikeToPostService } from 'src/app/Services/add-like-to-post/add-like-to-post.service';
import { DeleteLikeFromPostService } from 'src/app/Services/delete-like-from-post/delete-like-from-post.service';
import { GetPostLikesService } from 'src/app/Services/get-post-likes/get-post-likes.service';
@Component({
  selector: 'app-post-card',
  templateUrl: './post-card.component.html',
  styleUrls: ['./post-card.component.css']
})
export class PostCardComponent implements OnInit {

  @Input() post: Post = {
    postID: '',
    fk_UserID: '',
    content: '',
    likes: 0,
    privacyLevel: 0,
    dateCreated: new Date,
    dateModified: new Date
  }

  postLikes: string[] = [];
  liked: boolean = false;
  

  profile: any;

  constructor(   
    private PSS: GetProfileByUserIDService,
    private ALP: AddLikeToPostService,
    private DLP: DeleteLikeFromPostService,
    private GPL: GetPostLikesService,
    private dialog: MatDialog //Comment box from materials (sam)
  ) {}

  ngOnInit(): void {
    this.getProfile(this.post?.fk_UserID);

    console.log(this.postLikes);

    this.GPL.getPostLikes().subscribe(pls => {
      this.postLikes = pls;
      if(this.postLikes.includes(this.post.postID)){
        this.liked = true;
      }
    })
  }

  //When user clicks on comment bubble icon, it will open comment box (sam)
  onReplyClick(){
    this.dialog.open(CommentsComponent)
  }

  getProfile(userID: string): void {
    this.PSS.getProfile(userID).subscribe(prof => {
      this.profile = prof;
    })
  }

  clickLike(): void {
    if(this.liked) {
      this.deleteLike();
    } else {
      this.addLike();
    }
  }

  addLike(): void {
    this.ALP.addLike(this.post.postID).subscribe(numberOfLikes => {
      this.post.likes = numberOfLikes;
      this.liked=true;
    })
  }

  deleteLike(): void {
    this.DLP.deleteLike(this.post.postID).subscribe(numberOfLikes => {
      this.post.likes = numberOfLikes;
      this.liked=false;
    })
  }
}
