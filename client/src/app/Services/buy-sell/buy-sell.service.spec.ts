import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpTestingController, TestRequest, HttpClientTestingModule } from '@angular/common/http/testing';
import { fakeAsync, TestBed } from '@angular/core/testing';
import { environment } from 'src/environments/environment';
import { of } from 'rxjs';
import { BuySellService } from './buy-sell.service';

describe('BuySellService', () => {
  let service: BuySellService;
  let httpSpy: jasmine.SpyObj<HttpClient>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, HttpClientTestingModule]
    });;
    service = TestBed.inject(BuySellService);
  });

  // Created service test
  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  // Test for getting ticker data from Polygon.io api
  // it('Get ticker data', () => {
  //  pending()
  // });

}); //End of describe
