import { RouterTestingModule } from '@angular/router/testing';
import { ComponentFixture, async, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Location, CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthModule } from '@auth0/auth0-angular';
import { environment as env } from 'src/environments/environment';
import { inject, ɵcoerceToBoolean } from '@angular/core';
import { BuySellComponent } from './buy-sell.component';
import { HttpClientModule } from '@angular/common/http';

describe('BuySellComponent', () => {
  let component: BuySellComponent; // Component class
  let fixture: ComponentFixture<BuySellComponent>; // Fixture to hold component

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

  // Part of origional test
  it('should create', () => {
    expect(component).toBeTruthy();
  });

  // Test to see if title = 'Buy and Sell'
  it('Should create title Buy and Sell', () => {
    expect(component.title).toEqual('Buy and Sell');
  });

  // Tests the calculate button on the buy and sell page
  it('Should create Total button', () => {
    const btnElement = fixture.nativeElement;
    expect(btnElement.querySelector('button').textContent).toContain('Calculate Total')
  });

  // Test the payment button on the buy and sell
  it('Should test Payment button', fakeAsync(() => {
    const btnElement = fixture.debugElement.query(By.css('.buy-btn'));

    spyOn(component, 'onPayment')
    btnElement.triggerEventHandler('click', null);

    tick();
    expect(component.onPayment).toHaveBeenCalled();
  }));

  // Tests the cancel button on the buy and sell page
  it('Should test cancel Button', fakeAsync(() => {
    const btnElement = fixture.debugElement.query(By.css('.back-btn'));
    spyOn(component, 'resetForms')
    btnElement.triggerEventHandler('click', null);
    tick();
    expect(component.resetForms).toHaveBeenCalled();
  }));

  // Test for the total cost interprelation line on the buy sell page
  it('Should show the total cost interprelation', () => {
    expect(component.totalPrice).toEqual(0);
  });

  // Test for the buy/sell dropdown box on the buy sell page
  it("Should check or sell from dropdown box starts empty", () => {
    const bsDropbox = fixture.debugElement.query(By.css('.buy-sell-dropdown')).nativeElement;
    expect(bsDropbox.innerhtml).not.toBeNull();
  });

  // Checks to see if there is anything in the portfolio box
  it("Checks if portfolio dropdown box starts empty", () => {
    const portDropbox = fixture.debugElement.query(By.css('.portfolio-dropdown')).nativeElement;
    expect(portDropbox.innerhtml).not.toBeNull();
  });

  // Test for the ticker symbol fill in box on the buy sell page
  it('Should receive ticker symbol input', (done: DoneFn) => {
    const tickerInput = fixture.debugElement.query(By.css('.search-form-field '));
    tickerInput.nativeElement.value = 'A';
    tickerInput.nativeElement.dispatchEvent(new Event('input'));
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      fixture.detectChanges();
      console.log('sendInput : ', tickerInput.nativeElement.value);
      expect(tickerInput.nativeElement.value).toContain('A');
      done();
    });
  });

  // Test to check ticker search box starts empty
  it('Ticker search box should start empty', () => {
    const searchBox = fixture.debugElement.query(By.css('.search-form-field')).nativeElement;
    expect(searchBox.innerhtml).not.toBeNull();
  });

  // Test to check ticker order box starts empty
  it('Ticker order box should start empty', () => {
    const tickOrderBox = fixture.debugElement.query(By.css('.ticker-order-box')).nativeElement;
    expect(tickOrderBox.innerhtml).not.toBeNull();
  });

  // Test to make sure quantity box begins empty
  it('Quantity should start empty', () => {
    const qtyBox = fixture.debugElement.query(By.css('.quantity-input')).nativeElement;
    expect(qtyBox.innerhtml).not.toBeNull();
  });

  // Test for the ticker search box on the buy sell page
  it('Should return Ticker from search box', (done: DoneFn) => {
    const ticker = fixture.debugElement.query(By.css('.search-form-field'));
    ticker.nativeElement.value = 'AAPL';
    ticker.nativeElement.dispatchEvent(new Event('input'));
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      fixture.detectChanges();
      console.log('sendInput : ', ticker.nativeElement.value);
      expect(ticker.nativeElement.value).toContain('AAPL');
      done();
    });
  });

  // ************ Not yet working ************ //
  it("Checks if portfolio dropdown box when changed", () => {
    const portDropbox = fixture.debugElement.query(By.css('.portfolio-dropdown')).nativeElement;
    fixture.nativeElement.value = 'Buy';
    fixture.detectChanges()
    fixture.whenStable().then(() => {
      expect(portDropbox.nativeElement.value).toBe('Buy');
    })
  });

    // Test for the quantity box on the buy sell page
  // it('Should receive quantity in box', (done:DoneFn) => {
  //   const numInput = fixture.debugElement.query(By.css('.quantity-input'));
  //   numInput.nativeElement.value = '';
  //   numInput.nativeElement.dispatchEvent(new Event('input'));
  //   fixture.detectChanges();
  //   fixture.whenStable().then(() => {
  //     fixture.detectChanges();
  //     console.log('sendInput: ', numInput.nativeElement.value);
  //     expect(numInput.nativeElement.vale).toContain(1);
  //     done();
  //   })
  // });

  // Test for the ticker information chart on the buy sell page
  // it('Should show the ticker information chart', () => {
  //   pending();
  // });

}); // End of describe
