import { TestBed } from '@angular/core/testing';

import { CreatePortfolioService } from './create-portfolio.service';

describe('CreatePortfolioService', () => {
  let service: CreatePortfolioService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CreatePortfolioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
