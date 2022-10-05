import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { of } from 'rxjs';


import { CreatePortfolioModalComponent } from './create-portfolio-modal.component';

describe('CreatePortfolioModalComponent', () => {
  let component: CreatePortfolioModalComponent;
  let fixture: ComponentFixture<CreatePortfolioModalComponent>;

  const clickRes = [
    false
  ];
  const mockMatDialogRef:
    Pick<MatDialogRef<CreatePortfolioModalComponent>, 'close'> = {
      close: jasmine.createSpy('close').and.returnValue(of(clickRes))
    }

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
          useValue: { mockMatDialogRef }
        }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePortfolioModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should close a dialog after cancel', () => {
    expect(mockMatDialogRef.close).toBeNull;
  });
  
  it('should create', () => {
    expect(component).toBeTruthy();
  });

});
