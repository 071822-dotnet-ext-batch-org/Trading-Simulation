import { TestBed } from '@angular/core/testing';

import { DataShareService } from './data-share.service';

describe('DataShareService', () => {
  let service: DataShareService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataShareService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  
  it('should update portfolio', () => {
    expect(service.updatePortfolios).toBeTruthy();
  });
  
  it('should get updated portfolio', () => {
    expect(service.getUpdatedPortfolios).toBeTruthy();
  });

});
