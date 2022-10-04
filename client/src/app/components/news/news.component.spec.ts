import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import {NgxPaginationModule} from 'ngx-pagination';
 

import { NewsComponent } from './news.component';

describe('NewsComponent', () => {
  let component: NewsComponent;
  let fixture: ComponentFixture<NewsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientModule,  NgxPaginationModule ],
      declarations: [ NewsComponent]
      
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should show image slide', () => {
    expect(fixture.nativeElement.querySelector('[data-test="imageslide"]')).toBeTruthy();
  });

  it('should show Title News', () => {
    expect(fixture.nativeElement.querySelector('[data-test="News"]')).toBeTruthy();
  });



});
