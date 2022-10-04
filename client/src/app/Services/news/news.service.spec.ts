import { TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';

import { NewsService } from './news.service';

describe('NewsService', () => {
  let service: NewsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(NewsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get all news', () => {
    expect(service.getAllNews).toBeTruthy();
  });

  it('should get news', () => {
    expect(service.getNews).toBeTruthy();
  });
});
