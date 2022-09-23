import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular'

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
  }

  login(): void {
    this.auth.loginWithRedirect();
  }

}
