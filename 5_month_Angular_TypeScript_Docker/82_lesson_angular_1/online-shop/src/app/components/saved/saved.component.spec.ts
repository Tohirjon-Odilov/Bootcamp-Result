import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SavedComponent } from './saved.component';

describe('SavedComponent', () => {
  let component: SavedComponent;
  let fixture: ComponentFixture<SavedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SavedComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SavedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
