import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyCaruselComponent } from './my-carusel.component';

describe('MyCaruselComponent', () => {
  let component: MyCaruselComponent;
  let fixture: ComponentFixture<MyCaruselComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MyCaruselComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MyCaruselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
