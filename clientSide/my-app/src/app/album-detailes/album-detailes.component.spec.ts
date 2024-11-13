import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbumDetailesComponent } from './album-detailes.component';

describe('AlbumDetailesComponent', () => {
  let component: AlbumDetailesComponent;
  let fixture: ComponentFixture<AlbumDetailesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AlbumDetailesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AlbumDetailesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
