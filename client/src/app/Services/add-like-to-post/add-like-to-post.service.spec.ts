import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { AddLikeToPostService } from './add-like-to-post.service';


describe('AddLikeToPostService', () => {
  let service: AddLikeToPostService;
let str:string  = "strm";
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(AddLikeToPostService);
    
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('add-like-to-post',()=>{
    expect(service.addLike).toBeTruthy();
  });
});
