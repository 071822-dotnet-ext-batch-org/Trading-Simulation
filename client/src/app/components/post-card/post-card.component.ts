import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/Models/Posts';
import { GetProfileByUserIDService } from 'src/app/Services/get-profile-by-user-id/get-profile-by-user-id.service';

@Component({
  selector: 'app-post-card',
  templateUrl: './post-card.component.html',
  styleUrls: ['./post-card.component.css']
})
export class PostCardComponent implements OnInit {

  @Input() post: any;

  profile: any;

  constructor(   
    private PSS: GetProfileByUserIDService
  ) { }

  ngOnInit(): void {
    this.getProfile(this.post.fk_UserID)
  }

  getProfile(userID: string): void {
    this.PSS.getProfile(userID).subscribe(prof => {
      this.profile = prof;
    })
  }
}
