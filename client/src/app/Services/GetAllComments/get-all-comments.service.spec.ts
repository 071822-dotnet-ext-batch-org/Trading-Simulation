import { TestBed } from '@angular/core/testing';

import { GetAllCommentsService } from './get-all-comments.service';

describe('GetAllCommentsService', () => {
  let service: GetAllCommentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetAllCommentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
