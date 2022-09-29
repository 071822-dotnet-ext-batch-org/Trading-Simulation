import { TestBed } from '@angular/core/testing';

import { CuriencyapiService } from './curiencyapi.service';

describe('CuriencyapiService', () => {
  let service: CuriencyapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CuriencyapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
