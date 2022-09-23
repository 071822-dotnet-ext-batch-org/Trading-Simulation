import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { HomeComponent } from './components/home/home.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { PortfolioComponent } from './portfolio/portfolio.component';

const routes: Routes = [
  {path: '', redirectTo:'home',pathMatch:'full'},
  {path: "BuySell", component: BuySellComponent},
  {path: 'portfolio', component: PortfolioComponent},
  {path: 'home', component: HomeComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
