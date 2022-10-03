import { Component, OnInit } from '@angular/core';
import { ProfileServiceService } from 'src/app/Services/profile-service/profile-service.service';
import { Profile } from 'src/app/Models/Profile';
import { AuthService } from '@auth0/auth0-angular';
import { CreateProfileService } from 'src/app/Services/CreateProfile/create-profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profileToEdit?: Profile;
  profile: any;
  
  constructor(
    private ProService: ProfileServiceService,
    private AuthService: AuthService,
    private CreatePro: CreateProfileService,
    ) { }
    


  ngOnInit(): void {
   this.ProService.getProfiles().subscribe(data => {
    this.profile = data;
   });   
  }

  editProfile(profile: Profile) {
    this.profileToEdit = profile;
  }

  updateProfileList(update: Profile) {
    this.profile = update;  //check back on this
  }


  isClicked: boolean = false;

  createProfile (){
    this.AuthService.user$.subscribe(user => {
      this.CreatePro.createProfile(user?.name, user?.email, user?.picture, 0).subscribe(pro => {
        this.profile = pro
        console.log(pro)
       })
       
    })
   }

}
