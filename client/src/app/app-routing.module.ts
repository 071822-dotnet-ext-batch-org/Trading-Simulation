import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@auth0/auth0-angular';
import { PortfolioComponent } from './components/portfolio/portfolio.component';
import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { HomeComponent } from './components/home/home.component';
import { UserComponent } from './components/user/user.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';




const routes: Routes = [

  {path: '', redirectTo:'home',pathMatch:'full'},
  {path: "BuySell", component: BuySellComponent},
  {path: 'portfolio', component: PortfolioComponent},
  {path: 'home', component: HomeComponent }
  {path: 'user', component: UserComponent, canActivate: [AuthGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
