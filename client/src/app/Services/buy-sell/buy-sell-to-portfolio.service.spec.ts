import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { BuySellToPortfolioService } from './buy-sell-to-portfolio.service';

describe('BuySellToPortfolioService', () => {
  let service: BuySellToPortfolioService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(BuySellToPortfolioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  // Test for creating a but order
  it('createBuy', () => {

  });

  // Test for creating a sell order
  it('createSell', () => {

  });

}); // End of describe
