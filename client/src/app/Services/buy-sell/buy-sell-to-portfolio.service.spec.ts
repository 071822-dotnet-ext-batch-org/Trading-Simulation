import { HttpClientModule } from '@angular/common/http';
import { fakeAsync, TestBed } from '@angular/core/testing';
import { BuySellToPortfolioService } from './buy-sell-to-portfolio.service';
import { Observable, of } from 'rxjs';
import { getMap } from 'echarts';
import { BuyDto, SellDto } from 'src/app/Models/buy-sell/buySellApiCall';

// let postBuy = ['guid', 'string', 1, 1];
// let postSell = ['guid', 'string', 1, 1];

describe('BuySellToPortfolioService', () => {
  let service: BuySellToPortfolioService;
  let mockBuyStream: jasmine.SpyObj<BuyDto>;
  let mockSellStream: jasmine.SpyObj<SellDto>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(BuySellToPortfolioService);
    mockBuyStream = TestBed.get(BuySellToPortfolioService);
    mockSellStream = TestBed.get(BuySellToPortfolioService);
  });

  // Test to see if service created
  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  // Test to see if createBuy created
  it('should create a buy', () => {
    expect(service.createBuy).toBeTruthy();
  });

  // Test to see if createSell created
  it('should create a sell', () => {
    expect(service.createSell).toBeTruthy();
  });

}); //End describe
