import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Investment } from 'src/app/Models/Investment';
import { GetInvestmentsService } from 'src/app/Services/get-investments/get-investments.service';
import { MatTable } from '@angular/material/table';
import { BuySellService } from 'src/app/Services/buy-sell/buy-sell.service';
import { UpdatePriceService } from 'src/app/Services/update-price/update-price.service';
import { UpdatePrice } from 'src/app/Models/UpdatePrice';

@Component({
  selector: 'app-investments',
  templateUrl: './investments.component.html',
  styleUrls: ['./investments.component.css']
})
export class InvestmentsComponent implements OnInit {

  @Input() portfolioID: string = '';
  investments: Investment[] = [];
  myUpdatedPrices: UpdatePrice = {
    buys: [],
    portfolios: [],
    investments: []
  }
  loadingPrices: boolean = false;

  displayedColumns: string[] = [
    'symbol', 
    'currentAmount',
    'totalAmountBought',
    'totalAmountSold',
    'amountInvested',
    'averageBuyPrice',
    'currentPrice',
    'totalPNL',
    'dateModified',
    'update'
  ]

  constructor(
    private GIS: GetInvestmentsService,
    private BSS: BuySellService,
    private UPS: UpdatePriceService
  ) { }

  ngOnInit(): void {
    this.getInvestments(this.portfolioID);
    
  }

  getInvestments(portfolioID: string) {
    this.GIS.getInvestments(portfolioID).subscribe(inv => {
      this.investments = inv;
      console.log(this.investments);
    })
  }

  updatePrice(symbol: string) {
    this.loadingPrices = true;
    this.BSS.getTickerData(symbol).subscribe(td => {
      this.UPS.updatePrice(td.results[0].c, symbol).subscribe(up => {
        this.myUpdatedPrices = up;
        const updatedInvestments = this.investments.map(inv => {
          const u = this.myUpdatedPrices.investments.find(updInv => inv.investmentID === updInv.investmentID);
          if (u !== undefined) {
            inv = u;
          }

          return inv;
        })

        this.investments = [...updatedInvestments];
        this.loadingPrices = false;
      })
    })
  }
}
