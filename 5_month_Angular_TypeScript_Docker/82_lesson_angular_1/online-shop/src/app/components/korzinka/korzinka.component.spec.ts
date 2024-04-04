import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorzinkaComponent } from './korzinka.component';

describe('KorzinkaComponent', () => {
  let component: KorzinkaComponent;
  let fixture: ComponentFixture<KorzinkaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KorzinkaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(KorzinkaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
