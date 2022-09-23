import { Component, OnInit } from '@angular/core';
import { MatToolbar } from '@angular/material/toolbar';
import { BuySellComponent } from '../buy-sell/buy-sell.component';




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

  constructor() { }

  ngOnInit(): void {
  }

}
