import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { GetMyPortfoliosService } from './get-my-portfolios.service';

describe('GetMyPortfoliosService', () => {
  let service: GetMyPortfoliosService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(GetMyPortfoliosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
