import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuySellComponent } from './components/buy-sell/buy-sell.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';


const routes: Routes = [
  {path: "BuySell", component: BuySellComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
