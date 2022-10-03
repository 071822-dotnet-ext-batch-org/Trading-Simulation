import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpTestingController, TestRequest } from '@angular/common/http/testing';
import { fakeAsync, TestBed } from '@angular/core/testing';
import { environment } from 'src/environments/environment';
import { of } from 'rxjs';

import { BuySellService } from './buy-sell.service';

describe('BuySellService', () => {
  let service: BuySellService;
  let httpSpy: jasmine.SpyObj<HttpClient>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });;
    service = TestBed.inject(BuySellService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  // Test for getting ticker data from Polygon.io api
  // it('Get ticker data', fakeAsync((done: DoneFn) => {
  //   const ticker = 'A'
  //   const test = 'A'
  //   httpSpy.get.and.returnValue(of(ticker));

  //   service.getTickerData(ticker);
  //     expect(test).toEqual(ticker);
  //     expect(httpSpy.get).toHaveBeenCalled();
  //     done;
  // }))

}); //End of describe
