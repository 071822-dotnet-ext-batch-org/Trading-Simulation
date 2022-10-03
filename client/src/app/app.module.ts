import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Auth0ClientService, AuthModule } from '@auth0/auth0-angular'; //First we have downloaded Auth0 package (ng add @auth0/auth0-angular) then imoprted the package here (sam)
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
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { CdkAccordionModule } from '@angular/cdk/accordion';
import { MatTableModule } from '@angular/material/table';
import { ReactiveFormsModule } from '@angular/forms';



import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { RouterModule } from '@angular/router';

import { HomeService } from './Services/home/home.service';
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
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { GoogleChartsModule } from 'angular-google-charts';
import { CreatePortfolioModalComponent } from './components/create-portfolio-modal/create-portfolio-modal.component';
 
import { NgxPaginationModule } from 'ngx-pagination';
import { PaginationPipe } from './components/news/pagination.pipe';
 
 
import { environment as env } from 'src/environments/environment';
import { PostsComponent } from './components/posts/posts.component';
import { PostCardComponent } from './components/post-card/post-card.component';
import { InvestmentsComponent } from './components/investments/investments.component';
 
import { EditProfileComponent } from './components/edit-profile/edit-profile.component'
 
 

//import { EditProfileComponent } from './components/edit-profile/edit-profile.component';
import { CommentsComponent } from './components/comment/comments.component'

 

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
    CreatePortfolioModalComponent,
    PostsComponent,
    PostCardComponent,
    InvestmentsComponent,
    EditProfileComponent,

    PaginationPipe,
   
 
    CommentsComponent,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatProgressBarModule,
    NgxPaginationModule,
 
    CdkAccordionModule,
    FormsModule,
    HttpClientModule,
    MatDialogModule,
    MatTableModule,
    MatDialogModule,
    MatIconModule,
    ReactiveFormsModule,
    AuthModule.forRoot({
      domain: 'dev-pxtkabk5.us.auth0.com',             // getting connected with auth0 by using personal account information:
      clientId: 'XpigNZhlmh9GXncdhIqEy26BhT0M18yI',    // domain, clientID (they are unique to all users) (sam)
      audience: 'https://localhost:7280/api/Yoink',
      httpInterceptor: {
        allowedList: [
          env.baseURL + '/create-profile',
          env.baseURL + '/my-profile',
          env.baseURL + '/edit-profile',
          env.baseURL + '/my-portfolios',
          env.baseURL + '/create-portfolio',
          env.baseURL + '/all-investments',
          env.baseURL + '/create-buy',
          env.baseURL + '/create-sell',
          env.baseURL + '/update-current-price',
          env.baseURL + '/single-investment',
          env.baseURL + '/delete-portfolio',
          env.baseURL + '/remove-like-on-post',
          env.baseURL + '/add-like-on-post',
          env.baseURL + '/get-post-likes',
          env.baseURL + '/create-post'
        ],

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
