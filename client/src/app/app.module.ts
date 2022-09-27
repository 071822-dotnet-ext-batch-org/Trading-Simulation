import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Auth0ClientService, AuthModule } from '@auth0/auth0-angular';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthHttpInterceptor } from '@auth0/auth0-angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule } from '@angular/material/select';
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
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { RouterModule } from '@angular/router';


import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { SigninComponent } from './components/signin/signin.component';
import { SignOutComponent } from './components/sign-out/sign-out.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthButtonComponent } from './components/auth-button/auth-button.component';
import { UserComponent } from './components/user/user.component';
import { NewsComponent } from './components/news/news.component';
import { NewsService } from './Services/news/news.service';
import { ProfileComponent } from './components/profile/profile.component';

import { baseURL } from './Services/base-url';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { GoogleChartsModule } from 'angular-google-charts';
import { HomeLayoutComponent } from './components/home-layout/home-layout.component';
import { CreatePortfolioModalComponent } from './components/create-portfolio-modal/create-portfolio-modal.component';

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
    NewsComponent,
    ProfileComponent,
    HomeLayoutComponent,
    CreatePortfolioModalComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MatDialogModule,
    AuthModule.forRoot({
      domain: 'dev-pxtkabk5.us.auth0.com',
      clientId: 'XpigNZhlmh9GXncdhIqEy26BhT0M18yI',
      audience: 'https://localhost:7280/api/Yoink',
      httpInterceptor: {
        allowedList: [
          baseURL + '/create-profile',
          baseURL + '/my-profile',
          baseURL + '/edit-profile',
          baseURL + '/my-portfolios',
          baseURL + '/create-portfolio'
         ], //for now
      }

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
    MatGridListModule,
    RouterModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
    MatCheckboxModule,
    MatProgressSpinnerModule

  ],
providers: [
    NewsService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptor,
      multi: true
    },
    {
      provide: MatDialogRef,
      useValue: {}
    },
  ],


  bootstrap: [AppComponent]
})
export class AppModule { }
