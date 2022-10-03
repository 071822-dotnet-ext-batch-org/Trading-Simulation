import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BrowserDynamicTestingModule } from '@angular/platform-browser-dynamic/testing';

import { CreatePortfolioModalComponent } from './create-portfolio-modal.component';

describe('CreatePortfolioModalComponent', () => {
  let component: CreatePortfolioModalComponent;
  let fixture: ComponentFixture<CreatePortfolioModalComponent>;
  let dialog: MatDialog;

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

    TestBed.overrideModule(BrowserDynamicTestingModule, {
      set: {
        entryComponents: [CreatePortfolioModalComponent]
      }
    });
    TestBed.compileComponents();

    fixture = TestBed.createComponent(CreatePortfolioModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should open a dialog with a component', () => {
    const dialogRef = dialog.open(CreatePortfolioModalComponent, {
      data: { param: '1' }
    });

    // verify
    expect(dialogRef.componentInstance instanceof CreatePortfolioModalComponent).toBe(true);
  });
  
  it('should create', () => {
    expect(component).toBeTruthy();
  });

});
