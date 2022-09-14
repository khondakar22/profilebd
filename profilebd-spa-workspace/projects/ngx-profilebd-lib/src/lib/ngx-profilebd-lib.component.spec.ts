import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NgxProfilebdLibComponent } from './ngx-profilebd-lib.component';

describe('NgxProfilebdLibComponent', () => {
  let component: NgxProfilebdLibComponent;
  let fixture: ComponentFixture<NgxProfilebdLibComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NgxProfilebdLibComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NgxProfilebdLibComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
