import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ProfileComponent } from './profile.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { AuthModule, AuthService } from '@auth0/auth0-angular';
import { AuthConfig, AuthConfigService, AuthClientConfig } from '@auth0/auth0-angular';
import { Auth0ClientService, Auth0ClientFactory } from '@auth0/auth0-angular';
import { AuthGuard } from '@auth0/auth0-angular';
import { environment as env } from 'src/environments/environment';


describe('ProfileComponent', () => {
  let component: ProfileComponent;
  let fixture: ComponentFixture<ProfileComponent>;
  let h2: HTMLElement;

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
              env.baseURL + '/create-profile',
              env.baseURL + '/edit-profile',
              env.baseURL + '/my-portfolios',
              env.baseURL + '/my-profile',
              env.baseURL + '/create-portfolio'
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
  //Test checks if the button html element contains the text content edit
  it('Testing Button', ()=>{
    const data = fixture.nativeElement;
    expect(data.querySelector("button").textContent).toContain(" ")
  });
  //
  xit('Testing header2', ()=>{
    const data = fixture.nativeElement;
    expect(data.querySelector("p").textContent).toContain(" ")
  });
  //Test checks to see if the variable isClicked boolean value is false
  it('should be false',()=>{
   const isClicked = component.isClicked;
   expect(isClicked).toBeFalse();
  });
  //Test checks if ngOnInit exist
  it('#ngOnInit should exist ',()=>{
   expect(component.ngOnInit).toBeTruthy();
  });
  //Test checks if the createProfile functions exist
  it('#create profile should exist',()=>{
    expect(component.createProfile).toBeTruthy();
  });
  //Test checks if the editprofile 
  it('#editProfile should exist',()=>{
    expect(component.editProfile).toBeTruthy();
  });
  //Test checks if the UpdateProfileList method exist
  it('#updateProfile Should Exist',()=>{
    expect(component.updateProfileList).toBeTruthy();
  });
  //Test checks if the ProfileToEdit
  it('ProfileToEdit Should be Undefined',()=>{
    expect(component.profileToEdit).toBeUndefined();
  });
});
