import { TestBed } from '@angular/core/testing';

import { CreateProfileService } from './create-profile.service';

describe('CreateProfileService', () => {
  let service: CreateProfileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CreateProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
