import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { DeleteLikeFromPostService } from './delete-like-from-post.service';

describe('DeleteLikeToPostService', () => {
  let service: DeleteLikeFromPostService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(DeleteLikeFromPostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should delete like', () => {
    expect(service.deleteLike).toBeTruthy();
  });

});
