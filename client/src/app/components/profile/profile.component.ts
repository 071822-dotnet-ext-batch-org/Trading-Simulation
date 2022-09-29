import { Component, Input, OnInit } from '@angular/core';
import { ProfileServiceService } from 'src/app/Services/profile-service/profile-service.service';
import { Profile } from 'src/app/Models/Profile';
import { ResultType } from '@remix-run/router/dist/utils';
import { AuthService } from '@auth0/auth0-angular';
import { CreateProfileService } from 'src/app/Services/CreateProfile/create-profile.service';
import { UpdateProfileService } from 'src/app/Services/update-profile-service/update-profile.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
 
  constructor(private ProService: ProfileServiceService,
    private AuthService: AuthService,
    private CreatePro: CreateProfileService,
    private UpdatePro: UpdateProfileService,
    ) { }
    
    profile: any;
    showProfileName: boolean = true;
    showProfileEmail: boolean = true;
    showProfilePL: boolean = true;
    name = new FormControl('');
    email = new FormControl('');
    pl = new FormControl('');

  ngOnInit(): void {
   this.ProService.getProfiles().subscribe(data => {
    this.profile = data;
    this.profile.setValue(data.name);
    this.profile.setValue(data.email);
    this.profile.setValue(data.privacyLevel)
   });   
  }

  editName(): void {
    this.showProfileName = false;
  }

  editEmail(): void {
    this.showProfileEmail = false;
  }

  updateProfileName(): void {
    this.showProfileName = true;
    this.UpdatePro.updateProfile(this.name.value, null, null,).subscribe(update => {
      this.name.setValue(update.name)
      this.profile = update;
    })
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

   


  //  updateProfile(){
  //   this.AuthService.user$.subscribe(user => {
  //     this.UpdatePro.updateProfile(user?.name, user?.email, user?.picture, 0).subscribe(update => {
  //       console.log(update)
  //     })
  //   })
    
  //  }


  // initNewProfile() {
  //   this.profileToEdit = new Profile();
  // }

}
