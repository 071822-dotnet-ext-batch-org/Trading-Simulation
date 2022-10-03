import { TestBed } from '@angular/core/testing';

import { GetSingleInvestmentService } from './get-single-investment.service';

describe('GetSingleInvestmentService', () => {
  let service: GetSingleInvestmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetSingleInvestmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
