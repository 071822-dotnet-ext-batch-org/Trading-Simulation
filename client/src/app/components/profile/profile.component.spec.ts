import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ProfileComponent } from './profile.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { AuthModule, AuthService } from '@auth0/auth0-angular';
import { AuthConfig, AuthConfigService, AuthClientConfig } from '@auth0/auth0-angular';
import { Auth0ClientService, Auth0ClientFactory } from '@auth0/auth0-angular';
import { AuthGuard } from '@auth0/auth0-angular';
import { baseURL } from '../../Services/base-url';


describe('ProfileComponent', () => {
  let component: ProfileComponent;
  let fixture: ComponentFixture<ProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports:[
        RouterTestingModule,
        HttpClientTestingModule,
        AuthModule.forRoot({
          domain: 'dev-pxtkabk5.us.auth0.com',
          clientId: 'XpigNZhlmh9GXncdhIqEy26BhT0M18yI',
          audience: 'https://localhost:7280/api/Yoink',
          httpInterceptor: {
            allowedList: [
              baseURL + '/create-profile',
              baseURL + '/my-profile',
              baseURL + '/edit-profile',
              baseURL + '/my-portfolios',
              baseURL + '/create-portfolio'
             ], 
          }
    
        })
      ],
      declarations: [ ProfileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('Testing Button', ()=>{
    const data = fixture.nativeElement;
    expect(data.querySelector("button").textContent).toContain(" ")
  });
  it('Testing header2', ()=>{
    const data = fixture.nativeElement;
    expect(data.querySelector("h2").textContent).toContain(" ")
  });
});
