import { RouterTestingModule } from '@angular/router/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Location, CommonModule} from '@angular/common';
import { Router } from '@angular/router';
import { AuthModule } from '@auth0/auth0-angular';
import { environment as env } from 'src/environments/environment';
import { inject } from '@angular/core';
import { BuySellComponent } from './buy-sell.component';
import { HttpClientModule } from '@angular/common/http';
// import { MatSelect } from '@angular/material/select'; // added
// import { MatFormField } from '@angular/material/form-field'; // added
import { HarnessLoader } from '@angular/cdk/testing'; // added
import { TestbedHarnessEnvironment } from '@angular/cdk/testing/testbed'; // added
import { MatButtonHarness } from '@angular/material/button/testing'; // added

describe('BuySellComponent', () => {
  let component: BuySellComponent; // Component class
  let fixture: ComponentFixture<BuySellComponent>; // Fixture to hold component
  // let chosePortfolio: MatFormField; // added
  // let choseBuySell: MatFormField; // added
  // let tickerBoxQty: MatFormField; // added
  // let quantity: MatFormField; // added
  // let searchBox: MatFormField; // added
  let loader: HarnessLoader; // added
  let bedHarness: TestbedHarnessEnvironment; //added

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        // MatSelect, //added
        // MatFormField, // added
        HttpClientModule,
        AuthModule.forRoot({
          domain: 'dev-pxtkabk5.us.auth0.com',
          clientId: 'XpigNZhlmh9GXncdhIqEy26BhT0M18yI',
          audience: 'https://localhost:7280/api/Yoink',
          httpInterceptor: {
            allowedList: [
              env.baseURL + '/create-profile',
              env.baseURL + '/edit-profile',
              env.baseURL + '/my-portfolios',
              env.baseURL + '/my-profile',
              env.baseURL + '/create-portfolio'
             ],
          }
        })
      ],
      declarations: [ BuySellComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BuySellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  // Test to see if title = 'Buy and Sell'
  it('should have title Buy and Sell', () => {
    expect(component.title).toEqual('Buy and Sell');
  });


  // // Tests the calculate button on the buy and sell page
  // it('Calculate Total Button', () => {
  //   const data = fixture.nativeElement;
  //   expect(data.querySelector('button').textContent).toContain('Calculate Total')
  // });

  // Tests the cancel button on the buy and sell page
  // it('Cancel Button', () => {
  //   const data = fixture.nativeElement;
  //   expect(data.querySelector('button').textContent).toContain('Cancel')
  // });

  // // Tests the payment button on the buy and sell page
  // it('Payment Button', () => {
  //   const data = fixture.nativeElement;
  //   expect(data.querySelector('button').textContent).toContain('Payment')
  // });


  // Test for the total cost interprelation line on the buy sell page
  //TODO NEED to figure out how to get around ticker symbol
  // it('Show the total cost interprelation', () => {
  //   expect(calculateTotal().toEqual());
  // });

  // Test for the portfolio dropdown box on the buy sell page
  it('Portfolio box', () => {
    pending();
  });

  // Test for the buy/sell dropdown box on the buy sell page
  it('Buy Sell dropdown box', () => {
    pending();
  });

  // Test for the ticker symbol fill in box on the buy sell page
  it('Ticker symbol fill in box', () => {
    pending();
  });

  // Test for the quantity box on the buy sell page
  it('Quantity box', () => {
    pending();
  });

  // Test for the ticker information chart on the buy sell page
  it('Show the ticker information chart', () => {
    pending();
  });

  // Test for the ticker search box on the buy sell page
  it('Ticker search box', async () => {
    const ticker = fixture.debugElement.query(By.css('.search-form-field'));
    ticker.nativeElement.value = 'AAPL';
    ticker.nativeElement.dispatchEvent(new Event('input'));
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      fixture.detectChanges();
      console.log('sendInput : ', ticker.nativeElement.value);
      expect(ticker.nativeElement.value).toContain('AAPL');
    });
  });
});
