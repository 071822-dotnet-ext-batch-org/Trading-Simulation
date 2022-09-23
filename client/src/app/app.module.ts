import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthModule } from '@auth0/auth0-angular'; 

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
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { DefaultComponent } from './components/default/default.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { SigninComponent } from './components/signin/signin.component';
import { SignOutComponent } from './components/sign-out/sign-out.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthButtonComponent } from './components/auth-button/auth-button.component';
import { UserComponent } from './components/user/user.component';


@NgModule({
  declarations: [
    AppComponent,
    PortfolioComponent,
    NavBarComponent,
    BuySellComponent,
    HomeComponent,
    FooterComponent,
    SigninComponent,
    SignOutComponent,
    RegisterComponent,
    AuthButtonComponent,
    UserComponent,
    DefaultComponent


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,

    AuthModule.forRoot({
      domain: 'dev-pxtkabk5.us.auth0.com',
      clientId: 'XpigNZhlmh9GXncdhIqEy26BhT0M18yI',

    }),

    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    GoogleChartsModule,
    MatCardModule,
    MatMenuModule,
    RouterModule,
    

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


