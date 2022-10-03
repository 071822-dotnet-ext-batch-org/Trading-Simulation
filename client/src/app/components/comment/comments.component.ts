import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PostCardComponent } from '../post-card/post-card.component';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {

  constructor(
    @Inject(MAT_DIALOG_DATA) private postID: string
    ) { }

  ngOnInit(): void {
  }
  onSendClick(commentInput: HTMLInputElement){
    
    
  }
}
