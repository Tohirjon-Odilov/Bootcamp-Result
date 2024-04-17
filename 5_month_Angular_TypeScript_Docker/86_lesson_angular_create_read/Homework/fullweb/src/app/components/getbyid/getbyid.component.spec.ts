import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetbyidComponent } from './getbyid.component';

describe('GetbyidComponent', () => {
  let component: GetbyidComponent;
  let fixture: ComponentFixture<GetbyidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetbyidComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetbyidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
