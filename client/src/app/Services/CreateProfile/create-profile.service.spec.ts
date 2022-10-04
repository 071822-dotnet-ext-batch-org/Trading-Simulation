import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { CreateProfileService } from './create-profile.service';

describe('CreateProfileService', () => {
  let service: CreateProfileService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });;
    service = TestBed.inject(CreateProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should create a profile', () => {
    expect(service.createProfile).toBeTruthy();
  });
});
