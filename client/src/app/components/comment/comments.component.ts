import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Comment } from 'src/app/Models/Comment';
import { PostCardComponent } from '../post-card/post-card.component';
import { GetCommentsService } from 'src/app/Services/get-comments/get-comments.service';
import { CreateCommentService } from 'src/app/Services/create-comment/create-comment.service';
import { CreateCommentModel } from 'src/app/Models/CreateCommentModel';
import { Post } from 'src/app/Models/Posts';
@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {
  
 

  comments: Comment[] = [];
  content: string='';

  constructor(
    private commentsService: GetCommentsService,
    private createComment: CreateCommentService,
    public dialogRef: MatDialogRef<CommentsComponent>,
    private dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public data: Post
    ) { }

  ngOnInit(): void {
    this.commentsService.getAllComments(this.data.postID).subscribe(comments => {
      console.log('comments', comments);
      this.comments = comments;
    })
  }

    onSendClick(): void{
  
      this.dialogRef.close({
        content: this.content
      });

    };

  }

