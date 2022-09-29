import { TestBed } from '@angular/core/testing';

import { GetPostsService } from './get-posts.service';

describe('GetPostsService', () => {
  let service: GetPostsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetPostsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
