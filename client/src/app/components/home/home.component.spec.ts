import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { AuthModule } from '@auth0/auth0-angular';
import { environment as env } from 'src/environments/environment';

import { HomeComponent } from './home.component';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
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
      declarations: [ HomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  // tests p element and its content 
  it('should render title in a p tag', () => {
    const fixture = TestBed.createComponent(HomeComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('p').textContent).toContain('How Yoink! Works...it\'s easy as 1, 2, 3, Yoink!');
  });

  // tests title class and its content 
  it('should render `Step 1` in a class named title', () => {
    const board = fixture.debugElement.query(By.css('.title')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests title class and its content 
  it('should render `Step 2` in a class named title', () => {
    const board = fixture.debugElement.query(By.css('.title')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests title class and its content 
  it('should render `Step 3` in a class named title', () => {
    const board = fixture.debugElement.query(By.css('.title')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests title class and its content 
  it('should render `Step 4` in a class named title', () => {
    const board = fixture.debugElement.query(By.css('.title')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests subtitle class and its content 
  it('should render `Sign up` in a class named subtitle', () => {
    const board = fixture.debugElement.query(By.css('.subtitle')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests subtitle class and its content 
  it('should render `Create portfolio` in a class named subtitle', () => {
    const board = fixture.debugElement.query(By.css('.subtitle')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests subtitle class and its content 
  it('should render `Pick an investment` in a class named subtitle', () => {
    const board = fixture.debugElement.query(By.css('.subtitle')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });
  
  // tests subtitle class and its content 
  it('should render `Place a trade` in a class named subtitle', () => {
    const board = fixture.debugElement.query(By.css('.subtitle')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests content class and its content 
  it('should render `Create an account to have access to a portfolio` in a class named content', () => {
    const board = fixture.debugElement.query(By.css('.content')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests content class and its content 
  it('should render `Choose any amount to start investing` in a class named content', () => {
    const board = fixture.debugElement.query(By.css('.content')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });
  
  // tests content class and its content 
  it('should render `Use Yoink! news to do research on a potential investment` in a class named content', () => {
    const board = fixture.debugElement.query(By.css('.content')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests content class and its content 
  it('should render `Buy or Sell virtual stock` in a class named content', () => {
    const board = fixture.debugElement.query(By.css('.content')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests choose class and its content 
  it('should render `Why Choose Yoink!` in a class named choose', () => {
    const board = fixture.debugElement.query(By.css('.choose')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });

  // tests list element and its content 
  it('should render title in a li tag', () => {
    const fixture = TestBed.createComponent(HomeComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('li').textContent).toContain('Learn how to invest without risking your own money');
  });

  // tests explore class and its content 
  it('should render `Explore some of our tools and info to become more financially savvy` in a class named choose', () => {
    const board = fixture.debugElement.query(By.css('.explore')).nativeElement;
    expect(board.innerhtml).not.toBeNull();
  });
});
