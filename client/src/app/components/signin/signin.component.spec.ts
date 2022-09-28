import { RouterTestingModule } from '@angular/router/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Location, CommonModule} from '@angular/common';
import { Router } from '@angular/router';
import { AuthModule } from '@auth0/auth0-angular';
import { baseURL } from 'src/app/Services/base-url';

import { inject } from '@angular/core';
import { SigninComponent } from './signin.component';

describe('SigninComponent', () => {
  let component: SigninComponent;
  let fixture: ComponentFixture<SigninComponent>;

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
      declarations: [ SigninComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SigninComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create headr1', () => {
    const fixture = TestBed.createComponent(SigninComponent);
    fixture.detectChanges();
    const complied = fixture.debugElement.nativeElement;
    expect(complied.querySelector('h1').textContent).toContain('Yoink,');
  });
  it('test header2',()=>{
    const data = fixture.nativeElement.querySelector('h2');
    expect(data).toBeFalsy();
});
