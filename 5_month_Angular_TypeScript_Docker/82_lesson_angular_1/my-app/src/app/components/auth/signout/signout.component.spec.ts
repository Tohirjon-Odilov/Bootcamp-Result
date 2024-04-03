import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignoutComponent } from './signout.component';

describe('SignoutComponent', () => {
  let component: SignoutComponent;
  let fixture: ComponentFixture<SignoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SignoutComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SignoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
