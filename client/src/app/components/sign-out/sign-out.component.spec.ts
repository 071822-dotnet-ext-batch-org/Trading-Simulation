import {ComponentFixture,TestBed } from '@angular/core/testing';
import { AuthModule } from '@auth0/auth0-angular';
import { environment as env } from 'src/environments/environment';

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
      declarations: [ SignOutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SignOutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('test button', () => {
    const data = fixture.nativeElement.querySelector('button');
    expect(data).toBeTruthy();
  });
});
