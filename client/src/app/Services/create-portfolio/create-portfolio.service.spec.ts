import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { CreatePortfolioService } from './create-portfolio.service';

describe('CreatePortfolioService', () => {
  let service: CreatePortfolioService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(CreatePortfolioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should create a portfolio', () => {
    expect(service.createPortfolio).toBeTruthy();
  });
});
