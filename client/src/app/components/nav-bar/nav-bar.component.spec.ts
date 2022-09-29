import { RouterTestingModule } from '@angular/router/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Location, CommonModule} from '@angular/common';
import { Router } from '@angular/router';
import { AuthModule } from '@auth0/auth0-angular';
import { environment as env } from 'src/environments/environment';

import { inject } from '@angular/core';
import { NavBarComponent } from './nav-bar.component';

describe('NavBarComponent', () => {
  let component: NavBarComponent;
  let fixture: ComponentFixture<NavBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule.withRoutes([]),
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
      declarations: [ NavBarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('button should work', () => {
    const button: HTMLButtonElement = fixture.debugElement.nativeElement;
    expect(button).toBeTruthy;
  });
});
