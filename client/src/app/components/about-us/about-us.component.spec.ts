import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutUsComponent } from './about-us.component';

describe('AboutUsComponent', () => {
  let component: AboutUsComponent;
  let fixture: ComponentFixture<AboutUsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutUsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AboutUsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it(' h1 should contain about us',()=>{
    let h1 = fixture.nativeElement.querySelector('h1');
    expect(h1.textContent).toContain('About Us')
  });
  it('nginit should exist',()=>{
    let mocknginit = component.ngOnInit();
    expect(component.ngOnInit).toBeTruthy();
  });
  it('createClass should contain correct information',()=>{
    let createClass = fixture.nativeElement.querySelector('.create');
    expect(createClass.textContent).toContain('Creating a space for all to learn about investments')
  });
  it('test div about section',()=>{
    let div = fixture.nativeElement.querySelector('.about-section');
    expect(div).toBeTruthy();
  });
  it('test div row',()=>{
    let div = fixture.nativeElement.querySelector('.row');
    expect(div).toBeTruthy();
  });
  it('test div card',()=>{
    let div = fixture.nativeElement.querySelector('.card');
    expect(div).toBeTruthy();
  });
});
