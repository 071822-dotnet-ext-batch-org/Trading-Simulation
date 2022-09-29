import { TestBed } from '@angular/core/testing';

import { GetProfileByUserIDService } from './get-profile-by-user-id.service';

describe('GetProfileByUserIDService', () => {
  let service: GetProfileByUserIDService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetProfileByUserIDService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
