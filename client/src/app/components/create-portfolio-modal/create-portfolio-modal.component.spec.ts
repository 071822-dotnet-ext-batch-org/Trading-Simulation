import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePortfolioModalComponent } from './create-portfolio-modal.component';

describe('CreatePortfolioModalComponent', () => {
  let component: CreatePortfolioModalComponent;
  let fixture: ComponentFixture<CreatePortfolioModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatePortfolioModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePortfolioModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
