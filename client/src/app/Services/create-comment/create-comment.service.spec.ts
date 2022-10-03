import { TestBed } from '@angular/core/testing';

import { CreateCommentService } from './create-comment.service';

describe('CreateCommentService', () => {
  let service: CreateCommentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CreateCommentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
