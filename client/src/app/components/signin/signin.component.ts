import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular'; 
//AuthService holds the request methods that to use to sign a user in (Sam)


@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  constructor(public auth: AuthService) { } //using  AuthService (sam)

  ngOnInit(): void {
  }

  signin(): void {
    this.auth.loginWithRedirect(); 
//Performs a redirect to /authorize using the parameters provided as arguments. 
//Random and secure state and nonce parameters will be auto-generated. (sam)
  }

}
