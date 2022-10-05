import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';
import { HomeService } from './home.service';
import { Observable, of } from 'rxjs';
import { NextWeek } from '@material-ui/icons';
import { UNSAFE_NavigationContext } from 'react-router-dom';

describe('HomeService', () => {
  let service: HomeService;
  let httpClientSpy: jasmine.SpyObj<HttpClient>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(HomeService);
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
    service = new HomeService(httpClientSpy);
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
//tests the number of users from Http request
  it('should return expected number of users (HttpClient called once)', (done: DoneFn) => {
    const numOfUsers: number = 1
    httpClientSpy.get.and.returnValue(of(numOfUsers));
      
    service.getNumberOfUsers().subscribe({
      next: numOfUsers => {
        expect(numOfUsers)
        .withContext('expected users')
        .toEqual(numOfUsers);
        done();
      },
      error: done.fail
    });
    expect(httpClientSpy.get.calls.count())
      .withContext('number of users')
      .toBe(1)
    }); 
//tests the number of sells from http request
    it('should return expected number of sells (HttpClient called once)', (done: DoneFn) => {
      const numOfSells: number = 1
      httpClientSpy.get.and.returnValue(of(numOfSells));
        
      service.getNumberOfSells().subscribe({
        next: numOfSells => {
          expect(numOfSells)
          .withContext('expected users')
          .toEqual(numOfSells);
          done();
        },
        error: done.fail
      });
      expect(httpClientSpy.get.calls.count())
        .withContext('number of sells')
        .toBe(1)
      }); 
//tests the number of buys from an http request
    it('should return expected number of buys (HttpClient called once)', (done: DoneFn) => {
      const numOfBuys: number = 1
      httpClientSpy.get.and.returnValue(of(numOfBuys));
        
      service.getNumberOfBuys().subscribe({
        next: numOfBuys => {
          expect(numOfBuys)
          .withContext('expected buys')
          .toEqual(numOfBuys);
          done();
        },
        error: done.fail
      });
      expect(httpClientSpy.get.calls.count())
        .withContext('number of buys')
        .toBe(1)
      });
    //tests the number of posts from an http request  
    it('should return expected number of posts (HttpClient called once)', (done: DoneFn) => {
      const numOfPosts: number = 1
      httpClientSpy.get.and.returnValue(of(numOfPosts));
        
      service.getNumberOfPosts().subscribe({
        next: numOfPosts => {
          expect(numOfPosts)
          .withContext('expected posts')
          .toEqual(numOfPosts);
          done();
        },
        error: done.fail
      });
      expect(httpClientSpy.get.calls.count())
        .withContext('number of posts')
        .toBe(1)
      }); 
});
