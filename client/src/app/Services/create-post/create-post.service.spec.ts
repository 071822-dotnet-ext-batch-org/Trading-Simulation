import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { CreatePostService } from './create-post.service';

describe('CreatePostService', () => {
  let service: CreatePostService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(CreatePostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should create a post', () => {
    expect(service.createPost).toBeTruthy();
  });
});
