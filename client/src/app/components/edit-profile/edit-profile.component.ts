import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Profile } from 'src/app/Models/Profile';
import { UpdateProfileService } from 'src/app/Services/update-profile-service/update-profile.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {
  @Input() profile?: Profile;
  @Output() profileUpdated = new EventEmitter<Profile>();


  constructor(private UpdatePro: UpdateProfileService) { }

  ngOnInit(): void {
  }

  isClicked: boolean = false;
  
  updateProfile(profile:Profile) {
    this.UpdatePro
    .updateProfile(profile.name, profile.email, profile.picture, profile.privacyLevel)
    .subscribe((update: Profile) => this.profileUpdated.emit(update));
  }

}
