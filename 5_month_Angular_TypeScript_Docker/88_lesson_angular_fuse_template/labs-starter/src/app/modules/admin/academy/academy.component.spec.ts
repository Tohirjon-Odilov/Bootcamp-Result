import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcademyComponent } from './academy.component';

describe('AcademyComponent', () => {
  let component: AcademyComponent;
  let fixture: ComponentFixture<AcademyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AcademyComponent]
    });
    fixture = TestBed.createComponent(AcademyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
