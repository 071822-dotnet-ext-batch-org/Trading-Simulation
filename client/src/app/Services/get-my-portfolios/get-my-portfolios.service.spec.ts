import { TestBed } from '@angular/core/testing';

import { GetMyPortfoliosService } from './get-my-portfolios.service';

describe('GetMyPortfoliosService', () => {
  let service: GetMyPortfoliosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetMyPortfoliosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
