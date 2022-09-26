import { TestBed } from '@angular/core/testing';

import { BuySellToPortfolioService } from './buy-sell-to-portfolio.service';

describe('BuySellToPortfolioService', () => {
  let service: BuySellToPortfolioService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BuySellToPortfolioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
