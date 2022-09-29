import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
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
});
