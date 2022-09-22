import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { PortfolioComponent } from './portfolio/portfolio.component';

const routes: Routes = [
  {path: "BuySell", component: BuySellComponent},
  {path: 'portfolio', component: PortfolioComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
