import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@auth0/auth0-angular';
import { PortfolioComponent } from './components/portfolio/portfolio.component';
import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { UserComponent } from './components/user/user.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { HomeComponent } from './components/home/home.component';



const routes: Routes = [

  {path: 'user', component: UserComponent, canActivate: [AuthGuard]}
  {path: 'Portfolio', component: PortfolioComponent},
  {path: '', component: HomeComponent},
  {path: 'Home', component: HomeComponent}
  {path: "BuySell", component: BuySellComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
