import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
  }

  register(): void {
    this.auth.loginWithRedirect({
      screen_hint: 'signup'
    });
    
  }

}
