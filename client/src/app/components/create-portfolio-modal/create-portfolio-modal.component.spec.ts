import { OverlayContainer } from '@angular/cdk/overlay';
import { ViewContainerRef } from '@angular/core';
import { ComponentFixture, flush, TestBed } from '@angular/core/testing';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PortfolioComponent } from '../portfolio/portfolio.component';

import { CreatePortfolioModalComponent } from './create-portfolio-modal.component';

describe('CreatePortfolioModalComponent', () => {
  let component: CreatePortfolioModalComponent;
  let fixture: ComponentFixture<CreatePortfolioModalComponent>;
  let dialog: MatDialog;
  let overlayContainerElement: HTMLElement;
  let testViewContainerRef: ViewContainerRef;

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

  it('should close a dialog and get back a result', () => {
    const dialogRef = dialog.open(PortfolioComponent, {
      viewContainerRef: testViewContainerRef
    });
    flush();
    fixture.detectChanges();

    const beforeCloseHandler = jasmine.createSpy('beforeClose callback').and.callFake(() => {
      expect(overlayContainerElement.querySelector('mat-dialog-content'))
          .not.toBeNull('dialog container exists when beforeClose is called');
    });

    dialogRef.beforeClosed().subscribe(beforeCloseHandler);
    dialogRef.close('');
    fixture.detectChanges();
    flush();

    expect(beforeCloseHandler).toHaveBeenCalledWith('Bulbasaur');
    expect(overlayContainerElement.querySelector('mat-dialog-container')).toBeNull();
  });


  
  it('should create', () => {
    expect(component).toBeTruthy();
  });

});
