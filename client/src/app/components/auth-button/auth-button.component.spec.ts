import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Auth0ClientService } from '@auth0/auth0-angular/';
import { RouterTestingModule } from '@angular/router/testing';
import { By } from '@angular/platform-browser';
import { Location, CommonModule} from '@angular/common';
import { Router } from '@angular/router';

import { AuthButtonComponent } from './auth-button.component';
import { inject } from '@angular/core';

describe('AuthButtonComponent', () => {
  let component: AuthButtonComponent;
  let fixture: ComponentFixture<AuthButtonComponent>;

  beforeEach(async () => {
    
    await TestBed.configureTestingModule({
      declarations: [ AuthButtonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
