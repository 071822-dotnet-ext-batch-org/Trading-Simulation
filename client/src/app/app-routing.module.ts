import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@auth0/auth0-angular';

import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { UserComponent } from './components/user/user.component';
import { PortfolioComponent } from './portfolio/portfolio.component';


const routes: Routes = [
  {path: "BuySell", component: BuySellComponent, canActivate: [AuthGuard]},
  {path: 'portfolio', component: PortfolioComponent, canActivate: [AuthGuard]},
  {path: 'user', component: UserComponent, canActivate: [AuthGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
