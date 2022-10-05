import { formatDate } from '@angular/common';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { CreatePostService } from 'src/app/Services/create-post/create-post.service';
import { GetPostsService } from 'src/app/Services/get-posts/get-posts.service';
import { ProfileServiceService } from 'src/app/Services/profile-service/profile-service.service';

import { PostsComponent } from './posts.component';

const myProf = [
  'link-to-avatar',
  'guid',
  'me',
  'myself@me.com',
  '0'
]
const postCard1 = [
  'my guid',
  'my guid ref',
  'wow! I made money!',
  '2',
  '0',
  Date.now,
  Date.now
] // mocks the return information of the Post Model object in the Get Post Service
const postCard2 = [
  'its my comment!',
  '0'
] // mocks the return information of the Post Model object in the Create Post Service
const mockGetPostsService:
  Pick<GetPostsService, 'getAllPosts'> = {
   getAllPosts: jasmine.createSpy('getAllPosts').and.returnValue(of(postCard1))
} //mocks the Get Post Service

const mockCreatePostsService:
  Pick<CreatePostService, 'createPost'> = {
   createPost: jasmine.createSpy('createPost').and.returnValue(of(postCard2))
} //mocks the Create Post Service

const mockGetProfileServiceService:
  Pick<ProfileServiceService, 'getProfiles'> = {
   getProfiles: jasmine.createSpy('getProfiles').and.returnValue(of(myProf))
} //mocks the Create Post Service

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

// picture: string ;
// profileID: string ;
// name: string ;
// email: string ;
// privacyLevel: number ;

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
        {provide: GetPostsService, useValue: mockGetPostsService },
        {provide: CreatePostService, useValue: mockCreatePostsService },
        {provide: ProfileServiceService, useValue: mockGetProfileServiceService}
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should get posts', () => {
    expect(mockGetPostsService.getAllPosts).toHaveBeenCalled();
  });


  it('should create post', () => {
    expect(mockCreatePostsService.createPost).toHaveBeenCalled();
  });
  
  xit('should get my profile', () => {
    expect(mockGetProfileServiceService.getProfiles)
  });
  
  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
