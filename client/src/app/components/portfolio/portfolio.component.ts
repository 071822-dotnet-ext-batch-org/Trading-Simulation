import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Portfolio } from 'src/app/Models/Portfolio';
import { CreatePortfolioService } from 'src/app/Services/create-portfolio/create-portfolio.service';
import { DataShareService } from 'src/app/Services/data-share/data-share.service';
import { GetMyPortfoliosService } from 'src/app/Services/get-my-portfolios/get-my-portfolios.service';
import { CreatePortfolioModalComponent } from '../create-portfolio-modal/create-portfolio-modal.component';

import {MatDialog} from '@angular/material/dialog';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.css']
})
export class PortfolioComponent {

  items = ['Item 1', 'Item 2', 'Item 3', 'Item 4', 'Item 5'];
  // expandedIndex = 0;

  portfolios:Portfolio[] = [];
  portfolioID:string = '';
  loading:boolean = false;
  showPortfolios:boolean = true;

  constructor(
    private GMP: GetMyPortfoliosService,
    private CP: CreatePortfolioService,
    public dialog: MatDialog
  ) {
  }

  ngOnInit(): void {
    this.getPortfolios();
  }

  getPortfolios(): void {
    this.loading = true;
    this.GMP.getMyPortfolios().subscribe(ports => {
      this.portfolios = ports;
      this.loading = false;
    })
  }

  displayCreatePortfolioModal(): void {
    const dialogRef = this.dialog.open(CreatePortfolioModalComponent, {
      width: '400px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('closed');
      if(!result) return;
      this.CP.createPortfolio(result.name, result.originalLiquid, result.privacyLevel).subscribe(ports => this.portfolios = ports);
    })
  }

  displayInvestments(portfolioID:string): void {
    this.showPortfolios = false;
    this.portfolioID = portfolioID;
  }

  displayPortfolios(): void {
    this.showPortfolios = true;
  }

}
