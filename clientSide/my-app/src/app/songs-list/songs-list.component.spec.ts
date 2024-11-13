import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SongsListComponent } from './songs-list.component';

describe('SongsListComponent', () => {
  let component: SongsListComponent;
  let fixture: ComponentFixture<SongsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SongsListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SongsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
