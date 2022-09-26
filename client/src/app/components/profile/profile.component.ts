import { Component, Input, OnInit } from '@angular/core';
import { ProfileServiceService } from 'src/app/Services/profile-service/profile-service.service';
import { Profile } from 'src/app/Models/Profile';
import { ResultType } from '@remix-run/router/dist/utils';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  @Input() profile?: Profile;

  profiles?: Profile[];
  profileToEdit?: Profile;

  constructor(private ProService: ProfileServiceService,
              private AuthService: AuthService ) { }

  ngOnInit(): void { 
    // this.ProService
    // .getProfiles()
    // .subscribe((resul: Profile[]) => (this.profiles = result));
  }

  updateProfile(profile:Profile){}
  deleteProfile(profile:Profile){}
  createProfile(profile:Profile){}

  // initNewProfile() {
  //   this.profileToEdit = new Profile();
  // }

}


