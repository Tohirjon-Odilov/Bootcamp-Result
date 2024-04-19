import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModernComponent } from './modern.component';

describe('ModernComponent', () => {
  let component: ModernComponent;
  let fixture: ComponentFixture<ModernComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModernComponent]
    });
    fixture = TestBed.createComponent(ModernComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
