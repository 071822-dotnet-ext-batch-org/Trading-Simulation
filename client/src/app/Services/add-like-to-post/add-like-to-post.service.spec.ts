import { TestBed } from '@angular/core/testing';

import { AddLikeToPostService } from './add-like-to-post.service';

describe('AddLikeToPostService', () => {
  let service: AddLikeToPostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddLikeToPostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
