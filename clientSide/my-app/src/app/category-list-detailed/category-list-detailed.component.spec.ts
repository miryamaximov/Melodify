import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryListDetailedComponent } from './category-list-detailed.component';

describe('CategoryListDetailedComponent', () => {
  let component: CategoryListDetailedComponent;
  let fixture: ComponentFixture<CategoryListDetailedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CategoryListDetailedComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CategoryListDetailedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
