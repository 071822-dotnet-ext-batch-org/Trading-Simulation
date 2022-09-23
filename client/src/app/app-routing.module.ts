import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { PortfolioComponent } from './components/portfolio/portfolio.component';
import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { HomeComponent } from './components/home/home.component';



const routes: Routes = [
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
