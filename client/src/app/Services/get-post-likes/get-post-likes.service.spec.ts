import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { GetPostLikesService } from './get-post-likes.service';

describe('GetPostLikesService', () => {
  let service: GetPostLikesService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(GetPostLikesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
