import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { dateFormat } from 'highcharts';
import { of } from 'rxjs';
import { Post } from 'src/app/Models/Posts';

import { GetPostLikesService } from './get-post-likes.service';

describe('GetPostLikesService', () => {
  let service: GetPostLikesService;
  let httpClientSpy: jasmine.SpyObj<HttpClient>;

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
    service = new GetPostLikesService(httpClientSpy);

    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(GetPostLikesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get post likes', () => {
    expect(service.getPostLikes).toBeTruthy();
  });

  it('should return number of likes', (done: DoneFn) => {
    const expectedPosts: Post[] = [
      { postID: 'guid', fk_UserID: '', content: '', likes: 5, privacyLevel: 0, dateCreated: new Date('2022-10-05'), dateModified: new Date('2022-10-05')}, 
      { postID: 'guid', fk_UserID: '', content: '', likes: 200, privacyLevel: 0, dateCreated: new Date('2022-10-04'), dateModified: new Date('2022-10-04')}, 
    ];
    httpClientSpy.get.and.returnValue(of(expectedPosts));
      
    service.getPostLikes().subscribe({
      next(expectedPosts) {
        expect(expectedPosts)
        .toEqual(expectedPosts);
        done();
      },
      error: done.fail
    });
    expect(httpClientSpy.get.calls.count())
      .withContext('all likes from posts')
      .toBe(0)
    }); 

});
