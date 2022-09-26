import { Component, OnInit } from '@angular/core';
import { ProfileServiceService } from 'src/app/Services/profile-service/profile-service.service';
import { Profile } from 'src/app/Models/Profile';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profiles?: Profile[];

  constructor(private ProService: ProfileServiceService) { }

  ngOnInit(): void {
    this.getProfiles()
  }

  getProfiles(): void {
    this.ProService.getProfiles()
    .subscribe(profiles => this.profiles = profiles);
  }

}
