import { formatDate } from '@angular/common';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { getMap } from 'echarts';
import { observable, of } from 'rxjs';
import { GetPostsService } from 'src/app/Services/get-posts/get-posts.service';

import { PostsComponent } from './posts.component';

let postCard1 = [
  'my guid',
  'my guid ref',
  'wow! I made money!',
  '2',
  '0',
  Date.now,
  Date.now
]
const mockGetPostsService:
  Pick<GetPostsService, 'getAllPosts'> = {
   getAllPosts: jasmine.createSpy('getAllPosts').and.returnValue(of(postCard1))
}

// // postID: string;
// // fk_UserID: string;
// // content: string;
// // likes: number;
// // privacyLevel: number;
// // dateCreated: Date;
// // dateModified: Date;

// const okResponse = new Response(JSON.stringify(postCard1), {
//   status: 200,
//   statusText: 'OK',
// });

describe('PostsComponent', () => {
  let component: PostsComponent;
  let fixture: ComponentFixture<PostsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      declarations: [ PostsComponent ],
      providers: [
        {provide: GetPostsService, useValue: mockGetPostsService }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should get posts', () => {
    // const postSpy = jasmine.createSpy('get')
    // .and.returnValue(okResponse)
    expect(mockGetPostsService.getAllPosts).toHaveBeenCalled();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
