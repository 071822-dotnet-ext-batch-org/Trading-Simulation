import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';
import { HomeService } from './home.service';

describe('HomeService', () => {
  let service: HomeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(HomeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get buys', () => {
    expect(service.getNumberOfBuys).toBeTruthy();
  });

  it('should get posts', () => {
    expect(service.getNumberOfPosts).toBeTruthy();
  });
  
  it('should get sells', () => {
    expect(service.getNumberOfSells).toBeTruthy();
  });

  it('should get users', () => {
    expect(service.getNumberOfUsers).toBeTruthy();
  });
});
