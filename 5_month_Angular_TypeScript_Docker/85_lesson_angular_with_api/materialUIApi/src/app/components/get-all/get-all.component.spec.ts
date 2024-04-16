import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllComponent } from './get-all.component';

describe('GetAllComponent', () => {
  let component: GetAllComponent;
  let fixture: ComponentFixture<GetAllComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetAllComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
