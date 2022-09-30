import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AuthModule } from '@auth0/auth0-angular';
import { environment as env } from 'src/environments/environment';

import { UserComponent } from './user.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

describe('UserComponent', () => {
  let component: UserComponent;
  let fixture: ComponentFixture<UserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        FormsModule,
        ReactiveFormsModule,
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
      declarations: [ UserComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  //Tests the H1 html element to be false
    it('test header1 to be false', () => {
      const data = fixture.nativeElement.querySelector('h1');
      expect(data).toBeFalsy();
  });
  //Test the div with the row class to be false
   it('test div',()=>{
    const data = fixture.nativeElement.querySelector('.row');
    expect(data).toBeFalsy();
   });
   //Test the entire UserComponent to be working
   it('should create userpage', () =>{
    const fixture =TestBed.createComponent(UserComponent)
    const user = fixture.debugElement.componentInstance;
    expect(user).toBeTruthy();
   });
   //commented out for now
   xit('should create header1',()=>{
    const fixture = TestBed.createComponent(UserComponent);
    fixture.detectChanges();
    const complied = fixture.debugElement.nativeElement.querySelector('#titleInterpolation');
    expect(complied).toBeTruthy;
  });
  //Test the ProfileJson value to see if it's equal to ""
   it('testing profileJSON',()=>{
    expect(component.profileJson).toBe("")
   });
})
