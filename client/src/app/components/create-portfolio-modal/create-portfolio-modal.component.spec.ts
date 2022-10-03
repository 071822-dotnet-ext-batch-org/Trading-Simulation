import { OverlayContainer } from '@angular/cdk/overlay';
import { ComponentFixture, TestBed, inject } from '@angular/core/testing';
import { MatDialogModule,MatDialog, MatDialogRef } from '@angular/material/dialog';
import { BrowserDynamicTestingModule } from '@angular/platform-browser-dynamic/testing';

import { CreatePortfolioModalComponent } from './create-portfolio-modal.component';

describe('CreatePortfolioModalComponent', () => {
  let component: CreatePortfolioModalComponent;
  let fixture: ComponentFixture<CreatePortfolioModalComponent>;
  let dialog: MatDialog;
  let overlaycontainer: OverlayContainer

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MatDialogRef],
      providers: [ MatDialogModule ],
      declarations: [ CreatePortfolioModalComponent ]
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

  beforeEach(inject([MatDialog, OverlayContainer],
    (d: MatDialog, oc: OverlayContainer) => {
      dialog = d;
      overlaycontainer = oc;
    })
  );

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
