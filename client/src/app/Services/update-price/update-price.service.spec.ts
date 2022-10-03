import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { UpdatePriceService } from './update-price.service';

describe('UpdatePriceService', () => {
  let service: UpdatePriceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: MAT_DIALOG_DATA,
          useValue: {}
        },
        {
          provide: MatDialogRef,
          useValue: {}
        }
      ],
      imports: [HttpClientModule]
    });
    service = TestBed.inject(UpdatePriceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
