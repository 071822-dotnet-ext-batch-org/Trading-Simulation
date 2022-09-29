import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Investment } from 'src/app/Models/Investment';
import { GetInvestmentsService } from 'src/app/Services/get-investments/get-investments.service';
import { MatTable } from '@angular/material/table';

@Component({
  selector: 'app-investments',
  templateUrl: './investments.component.html',
  styleUrls: ['./investments.component.css']
})
export class InvestmentsComponent implements OnInit {

  @Input() portfolioID: string = '';
  investments: Investment[] = [];

  displayedColumns: string[] = [
    'symbol', 
    'amountInvested',
    'currentAmount',
    'currentPrice',
    'totalAmountBought',
    'totalAmountSold',
    'totalPNL',
    'dateModified'
  ]

  constructor(private GIS: GetInvestmentsService) { }

  ngOnInit(): void {
    this.getInvestments(this.portfolioID);

  }

  getInvestments(portfolioID: string) {
    this.GIS.getInvestments(portfolioID).subscribe(inv => {
      this.investments = inv;
    })
  }
}
