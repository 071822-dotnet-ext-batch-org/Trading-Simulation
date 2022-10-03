import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CreateCommentService } from 'src/app/Services/create-comment/create-comment.service';
import { PostCardComponent } from '../post-card/post-card.component';
import { AuthService } from '@auth0/auth0-angular';
import { GetAllCommentsService } from 'src/app/Services/GetAllComments/get-all-comments.service';
import { Comment } from 'src/app/Models/Comment';
@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {

  comment: any;

  constructor(
    private Auth0: AuthService,
    private CC: CreateCommentService,
    private GAC: GetAllCommentsService,
    public dialog: MatDialog
    

    ) { }

  ngOnInit(): void {
    this.GAC.getAllComments().subscribe(data => {
      this.comment = data;
    })
  }



  public onSendClick(content:string): void{
    this.CC.createComment(content).subscribe(comm => {
      this.comment = comm
    })
  }
}
