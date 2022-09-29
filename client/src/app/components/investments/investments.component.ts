import { Component, OnInit, Input } from '@angular/core';
import { Investment } from 'src/app/Models/Investment';
import { GetInvestmentsService } from 'src/app/Services/get-investments/get-investments.service';

@Component({
  selector: 'app-investments',
  templateUrl: './investments.component.html',
  styleUrls: ['./investments.component.css']
})
export class InvestmentsComponent implements OnInit {

  @Input() portfolioID: string = '';
  investments: Investment[] = [];

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
