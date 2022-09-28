import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Profile } from 'src/app/Models/Profile';


@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
  }

  signin(): void {
    this.auth.signin$.subscribe(Profile =>(this.profileJson = JSON.stringify(profile, null,2))
    );
  }

}
