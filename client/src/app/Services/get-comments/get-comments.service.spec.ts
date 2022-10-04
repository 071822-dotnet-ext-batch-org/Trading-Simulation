import { TestBed } from '@angular/core/testing';

import { GetCommentsService } from './get-comments.service';

describe('GetCommentsService', () => {
  let service: GetCommentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetCommentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
