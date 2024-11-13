import { TestBed } from '@angular/core/testing';

import { AlbumsDetailService } from './albums-detail.service';

describe('AlbumsDetailService', () => {
  let service: AlbumsDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AlbumsDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
