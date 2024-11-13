import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPlaylistsComponent } from './user-playlists.component';

describe('UserPlaylistsComponent', () => {
  let component: UserPlaylistsComponent;
  let fixture: ComponentFixture<UserPlaylistsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserPlaylistsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserPlaylistsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
