import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { DeletePortfolioService } from './delete-portfolio.service';

describe('DeletePortfolioService', () => {
  let service: DeletePortfolioService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(DeletePortfolioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
