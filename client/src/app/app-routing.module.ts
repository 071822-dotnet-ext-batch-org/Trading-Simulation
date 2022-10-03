import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@auth0/auth0-angular';
import { PortfolioComponent } from './components/portfolio/portfolio.component';
import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { HomeComponent } from './components/home/home.component';
import { UserComponent } from './components/user/user.component';
import { NewsComponent } from './components/news/news.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { ProfileComponent } from './components/profile/profile.component';
import { PostsComponent } from './components/posts/posts.component';
import { AboutUsComponent } from './components/about-us/about-us.component';





const routes: Routes = [

  {path: '', redirectTo:'home',pathMatch:'full'},
  {path: "BuySell", component: BuySellComponent, canActivate: [AuthGuard]},
  {path: 'Portfolio', component: PortfolioComponent, canActivate: [AuthGuard]},
  {path: 'home', component: HomeComponent },
  {path: 'user', component: UserComponent, canActivate: [AuthGuard]},
  {path: 'News', component: NewsComponent},
  {path: 'Profile', component: ProfileComponent },
  {path: 'Posts', component: PostsComponent }, 
  {path: "postfeed", component: PostsComponent},//comeback for this
  {path: "AboutUs", component: AboutUsComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
