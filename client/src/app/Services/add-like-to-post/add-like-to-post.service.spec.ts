import { TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { AddLikeToPostService } from './add-like-to-post.service';
import { HttpTestingController } from '@angular/common/http/testing';


describe('AddLikeToPostService', () => {
  let service: AddLikeToPostService;
let str:string  = "strm";
let homecontroller : HttpTestingController;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports : [HttpClientModule,
      HttpTestingController]
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
