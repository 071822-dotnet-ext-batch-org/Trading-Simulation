import { Component, OnInit } from '@angular/core';
import { BuySellComponent } from '../buy-sell/buy-sell.component';
import { AuthService } from '@auth0/auth0-angular';



@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
  template: `
    <h1>Navigation Bar</h1>
  `,
  styles: ['h1 {font-weight: normal;}']
})
export class NavBarComponent implements OnInit {

  constructor(public auth:AuthService) { }

  ngOnInit(): void {
  }

}
