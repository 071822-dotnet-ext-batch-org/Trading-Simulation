import { TestBed } from '@angular/core/testing';

import { UpdatePriceService } from './update-price.service';

describe('UpdatePriceService', () => {
  let service: UpdatePriceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UpdatePriceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
