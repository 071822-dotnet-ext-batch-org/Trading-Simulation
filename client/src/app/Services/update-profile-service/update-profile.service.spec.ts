import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { UpdateProfileService } from './update-profile.service';

describe('UpdateProfileService', () => {
  let service: UpdateProfileService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(UpdateProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
