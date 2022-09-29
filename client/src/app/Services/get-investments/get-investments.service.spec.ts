import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { GetInvestmentsService } from './get-investments.service';

describe('GetInvestmentsService', () => {
  let service: GetInvestmentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(GetInvestmentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
