import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular'; 
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-sign-out',
  templateUrl: './sign-out.component.html',
  styleUrls: ['./sign-out.component.css']
})
export class SignOutComponent implements OnInit {

  constructor(public auth: AuthService, @Inject(DOCUMENT) private doc: Document) { }
  // Document: Any web page loaded in the browser and serves as an entry point into the web page's content, which is the DOM tree.(sam)

  ngOnInit(): void {
  }

  signout():void{
    this.auth.logout({
      returnTo: this.doc.location.origin
      // returnTo returns the user to the homepage after signout (sam)
    });
    //Clears the application session and performs a redirect to logout, 
    //using the parameters provided as arguments, to clear the Auth0 session. (sam)
  }//method closing

}
