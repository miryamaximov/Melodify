import { TestBed } from '@angular/core/testing';

import { SharedPlaylistsDetailService } from './shared-playlists-detail.service';

describe('SharedPlaylistsDetailService', () => {
  let service: SharedPlaylistsDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SharedPlaylistsDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
