import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPlaylistDetailsComponent } from './user-playlist-details.component';

describe('UserPlaylistDetailsComponent', () => {
  let component: UserPlaylistDetailsComponent;
  let fixture: ComponentFixture<UserPlaylistDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserPlaylistDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserPlaylistDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
