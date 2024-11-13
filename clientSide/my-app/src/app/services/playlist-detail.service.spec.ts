import { TestBed } from '@angular/core/testing';

import { PlaylistDetailService } from './playlist-detail.service';

describe('PlaylistDetailService', () => {
  let service: PlaylistDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlaylistDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
