import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { CuriencyapiService } from './curiencyapi.service';

describe('CuriencyapiService', () => {
  let service: CuriencyapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(CuriencyapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get currency data', () => {
    expect(service.getcurrencydata).toBeTruthy();
  });
  
});
