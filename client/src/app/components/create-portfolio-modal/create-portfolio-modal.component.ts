import { Component, Inject, OnInit } from '@angular/core';
import { CreatePortfolioService } from 'src/app/Services/create-portfolio/create-portfolio.service';
import { DataShareService } from 'src/app/Services/data-share/data-share.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { CreatePortfolioDialog } from 'src/app/Models/CreatePortfolioDialog';

@Component({
  selector: 'app-create-portfolio-modal',
  templateUrl: './create-portfolio-modal.component.html',
  styleUrls: ['./create-portfolio-modal.component.css']
})
export class CreatePortfolioModalComponent implements OnInit {

  name: string = '';
  originalLiquid: number = 0;
  checked: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<CreatePortfolioModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CreatePortfolioDialog,
  ) {
  }

  ngOnInit(): void {
  }

  cancel(): void {
    this.dialogRef.close();
  }

  createPortfolio(): void {
    this.dialogRef.close({name: this.name, originalLiquid: Number(this.originalLiquid), privacyLevel: this.checked ? 1 : 0});
  }

}
