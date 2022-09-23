import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { PortfolioComponent } from './components/portfolio/portfolio.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';

import { GoogleChartsModule } from 'angular-google-charts';

import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { BuySellComponent } from './components/buy-sell/buy-sell.component';

import { HomeComponent } from './components/home/home.component';
import { DefaultComponent } from './components/default/default.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    AppComponent,
    PortfolioComponent,
    NavBarComponent,
    BuySellComponent,
    HomeComponent,
    DefaultComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    GoogleChartsModule,
    MatCardModule,
    MatMenuModule,
    RouterModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


