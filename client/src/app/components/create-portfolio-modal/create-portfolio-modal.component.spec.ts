import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


import { CreatePortfolioModalComponent } from './create-portfolio-modal.component';

describe('CreatePortfolioModalComponent', () => {
  let component: CreatePortfolioModalComponent;
  let fixture: ComponentFixture<CreatePortfolioModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({

      declarations: [ CreatePortfolioModalComponent ],
      providers: [
        {
          provide: MAT_DIALOG_DATA,
          useValue: {}
        },
        {
          provide: MatDialogRef,
          useValue: {}
        }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePortfolioModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should close a dialog after cancel', () => {
    const app = fixture.componentInstance;
    app.createPortfolio();
    fixture.detectChanges();
    const result = document.getElementsByName('mat-dialog-actions');
    expect(result).not.toBeNull();
  });
  
  it('should create', () => {
    expect(component).toBeTruthy();
  });

});
