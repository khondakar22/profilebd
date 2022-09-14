import { TestBed } from '@angular/core/testing';

import { NgxProfilebdLibService } from './ngx-profilebd-lib.service';

describe('NgxProfilebdLibService', () => {
  let service: NgxProfilebdLibService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NgxProfilebdLibService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
