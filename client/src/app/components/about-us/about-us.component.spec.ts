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
//Test checks if the component is truthy
  it('should create', () => {
    expect(component).toBeTruthy();
  });
// Test checks the create class in the html h1 element to see if it contains  "About us"
  it(' h1 should contain about us',()=>{
    let h1 = fixture.nativeElement.querySelector('h1');
    expect(h1.textContent).toContain('About Us')
  });
// Test checks if the ngOnInit is truthy
  it('nginit should exist',()=>{
    let mocknginit = component.ngOnInit();
    expect(component.ngOnInit).toBeTruthy();
  });
// test checks the the create class element to see if it contains the text Creating a space for all to learn about investments
  it('createClass should contain correct information',()=>{
    let createClass = fixture.nativeElement.querySelector('.create');
    expect(createClass.textContent).toContain('Creating a space for all to learn about investments')
  });
//test the div that contains the about section class to see if it's truthy
  it('test div about section',()=>{
    let div = fixture.nativeElement.querySelector('.about-section');
    expect(div).toBeTruthy();
  });
//test the div that contains row to see if it's truthy
  it('test div row',()=>{
    let div = fixture.nativeElement.querySelector('.row');
    expect(div).toBeTruthy();
  });
//test the div with the card class is truthy
  it('test div card',()=>{
    let div = fixture.nativeElement.querySelector('.card');
    expect(div).toBeTruthy();
  });
});
