import {ComponentFixture,TestBed } from '@angular/core/testing';
import { AuthModule } from '@auth0/auth0-angular';
import { baseURL } from 'src/app/Services/base-url';

import { inject } from '@angular/core';
import { SignOutComponent } from './sign-out.component';

describe('SignOutComponent', () => {
  let component: SignOutComponent;
  let fixture: ComponentFixture<SignOutComponent>;

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
      declarations: [ SignOutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SignOutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create test1', () => {
    const fixture = TestBed.createComponent(SignOutComponent);
    fixture.detectChanges();
    const complied = fixture.debugElement.nativeElement;
    expect(complied.querySelector('h1').textContent).toContain('Yoink,');
  });
  it('test header2', () => {
    const data = fixture.nativeElement.querySelector('h2');
    expect(data).toBeFalsy();
  });
});
