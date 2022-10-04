import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Comment } from 'src/app/Models/Comment';
import { PostCardComponent } from '../post-card/post-card.component';
import { GetCommentsService } from 'src/app/Services/get-comments/get-comments.service';
import { CreateCommentService } from 'src/app/Services/create-comment/create-comment.service';
import { CreateCommentModel } from 'src/app/Models/CreateCommentModel';
@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {
  @Input() fk_UserId!: string;

  comments: Comment[] = [];
  comment: CreateCommentModel[] = [];
  newComments: any

  constructor(
    private commentsService: GetCommentsService,
    private createComment: CreateCommentService,
    public dialogRef: MatDialogRef<CommentsComponent>,
    @Inject(MAT_DIALOG_DATA) private postId: string
    ) { }

  ngOnInit(): void {
    this.commentsService.getAllComments().subscribe(comments => {
      console.log('comments', comments);
      this.comments = comments;
    })
  }

  onSendClick(newComment: CreateCommentModel): void {
    console.log('addComment', newComment);
    this.createComment.createComment(newComment.postId, newComment.content)
    .subscribe( newComm =>{
      this.newComments = newComm;
    });

  //   this.dialogRef.afterClosed().subscribe(result => {
  //     console.log('closed');
  //     if(!result)return;
  //     this.createComment.createComment(result.postId, result.content).subscribe(comm => {
  //      this.comment.unshift(comm);
  //     });
      
  //   })
  // }
 
  // dialogRef.afterClosed().subscribe(result => {
  //   console.log('closed');
  //   if(!result)return;
    
  // });
  }
}
