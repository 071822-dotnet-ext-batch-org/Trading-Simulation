import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { CreateCommentService } from './create-comment.service';

describe('CreateCommentService', () => {
  let service: CreateCommentService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(CreateCommentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should create a comment', () => {
    expect(service.createComment).toBeTruthy();
  });
});
