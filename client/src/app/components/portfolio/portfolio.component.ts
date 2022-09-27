import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Portfolio } from 'src/app/Models/Portfolio';
import { CreatePortfolioService } from 'src/app/Services/create-portfolio/create-portfolio.service';
import { DataShareService } from 'src/app/Services/data-share/data-share.service';
import { GetMyPortfoliosService } from 'src/app/Services/get-my-portfolios/get-my-portfolios.service';
import { CreatePortfolioModalComponent } from '../create-portfolio-modal/create-portfolio-modal.component';

import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.css']
})
export class PortfolioComponent {

  portfolios:Portfolio[] = [];


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
    this.GMP.getMyPortfolios().subscribe(ports => {
      this.portfolios = ports;
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

  displayPortfolio(portfolioID: string): void {
    
  }

}
