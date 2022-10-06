import { HttpClient, HttpClientModule, HttpErrorResponse } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';
import { Post } from 'src/app/Models/Posts';
import { AddLikeToPostService } from './add-like-to-post.service';


describe('AddLikeToPostService', () => {
  let service: AddLikeToPostService;
  let httpClientSpy: jasmine.SpyObj<HttpClient>;

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['post']);
    service = new AddLikeToPostService(httpClientSpy);

    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(AddLikeToPostService);
    
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  //tests if the http request updates the like and returns a new post object with the updated likes
  it('should add update to a post', () => {
   (done: DoneFn) => {
    const numOfLikes : number = 1 

    httpClientSpy.post.and.returnValue(of(numOfLikes));

    service.addLike('guid').subscribe({
      next(likes) {
        expect(likes)
        .toEqual(numOfLikes);
        done();
      },
      error: done.fail
    });
    expect(httpClientSpy.get.calls.count())
    .withContext('one call')
    .toBe(1);  
  }
  });

  //tests i the addLike method is truthy
  it('add-like-to-post',()=>{
    expect(service.addLike).toBeTruthy();
  });
});
