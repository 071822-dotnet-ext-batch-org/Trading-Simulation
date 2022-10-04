import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { GetSingleInvestmentService } from './get-single-investment.service';

describe('GetSingleInvestmentService', () => {
  let service: GetSingleInvestmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(GetSingleInvestmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get single investment', () => {
    expect(service.getSingleInvestment).toBeTruthy();
  });
});
