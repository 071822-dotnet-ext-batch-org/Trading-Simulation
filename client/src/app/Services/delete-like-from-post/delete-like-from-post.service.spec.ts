import { TestBed } from '@angular/core/testing';

import { DeleteLikeFromPostService } from './delete-like-from-post.service';

describe('DeleteLikeToPostService', () => {
  let service: DeleteLikeFromPostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeleteLikeFromPostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
