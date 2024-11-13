import { TestBed } from '@angular/core/testing';

import { CategoriesDetailService } from './categories-detail.service';

describe('CategoriesDetailService', () => {
  let service: CategoriesDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoriesDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
