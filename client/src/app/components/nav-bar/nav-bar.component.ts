import { Component, OnInit } from '@angular/core';
import { MatToolbar } from '@angular/material/toolbar';
import { BuySellComponent } from '../buy-sell/buy-sell.component';
import { AuthService } from '@auth0/auth0-angular';
import { environment } from 'src/environments/environment';




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

  logo: string = environment.yoinkLogo;

  constructor(public auth:AuthService) { }

  ngOnInit(): void {
  }

}
