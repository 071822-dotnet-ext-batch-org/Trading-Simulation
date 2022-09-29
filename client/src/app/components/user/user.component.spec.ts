import { RouterTestingModule } from '@angular/router/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Location, CommonModule} from '@angular/common';
import { Router } from '@angular/router';
import { AuthModule } from '@auth0/auth0-angular';
import { baseURL } from 'src/app/Services/base-url';

import { inject } from '@angular/core';
import { UserComponent } from './user.component';

describe('UserComponent', () => {
  let component: UserComponent;
  let fixture: ComponentFixture<UserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        AuthModule.forRoot({
          domain: 'dev-pxtkabk5.us.auth0.com',
          clientId: 'XpigNZhlmh9GXncdhIqEy26BhT0M18yI',
          httpInterceptor: {
            allowedList: [
              baseURL + '/CreateProfileAsync',
              baseURL + '/GetProfileByUserIDAsync',
              baseURL + '/EditProfileAsync'
             ], //for now
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

  
    it('test header1 to be false', () => {
      const data = fixture.nativeElement.querySelector('h1');
      expect(data).toBeFalsy();
  });
   it('test div',()=>{
    const data = fixture.nativeElement.querySelector('.row');
    expect(data).toBeFalsy();
   });
   it('test header2',()=>{
    const data = fixture.nativeElement.querySelector('h2');
    expect(data).toBeFalsy();
   });
   it('test header5',()=>{
    const data = fixture.nativeElement.querySelector('h5');
    expect(data).toBeFalsy();
   });
   it('should create userpage', () =>{
    const fixture =TestBed.createComponent(UserComponent)
    const user = fixture.debugElement.componentInstance;
    expect(user).toBeTruthy();
   });
   it('should create header1',()=>{
    const fixture = TestBed.createComponent(UserComponent);
    fixture.detectChanges();
    const complied = fixture.debugElement.nativeElement;
    expect(complied.querySelector('h1').textContent).toContain('Yoink,');
   });
   it('testing profileJSON',()=>{
    expect(component.profileJson).toBe("")
   });
})
