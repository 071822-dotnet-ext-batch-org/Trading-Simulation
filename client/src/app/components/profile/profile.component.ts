import { Component, Input, OnInit } from '@angular/core';
import { ProfileServiceService } from 'src/app/services/profile-service/profile-service.service';
import { Profile } from 'src/app/Models/Profile';
import { ResultType } from '@remix-run/router/dist/utils';
import { AuthService } from '@auth0/auth0-angular';
import { CreateProfileService } from 'src/app/services/CreateProfile/create-profile.service';
import { UpdateProfileService } from 'src/app/services/update-profile-service/update-profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profile: any;

  constructor(private ProService: ProfileServiceService,
              private AuthService: AuthService,
              private CreatePro: CreateProfileService,
              private UpdatePro: UpdateProfileService,
              ) { }

  ngOnInit(): void {
    // this.ProService
    // .getProfiles()
    // .subscribe((resul: Profile[]) => (this.profiles = result));
  }
  createProfile(){
    this.AuthService.user$.subscribe(user => {
      this.CreatePro.createProfile(user?.name, user?.email, user?.picture, 0).subscribe(pro => {
        this.profile = pro
        console.log(pro)
       })
    })
   }


  // initNewProfile() {
  //   this.profileToEdit = new Profile();
  // }

}
