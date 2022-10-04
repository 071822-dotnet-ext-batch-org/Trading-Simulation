import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { ProfileServiceService } from './profile-service.service';

describe('ProfileServiceService', () => {
  let service: ProfileServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });;
    service = TestBed.inject(ProfileServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get profiles', () => {
    expect(service.getProfiles).toBeTruthy();
  });
});
