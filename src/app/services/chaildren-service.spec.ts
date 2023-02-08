import { TestBed } from '@angular/core/testing';

import { ChaildrenService } from './chaildren-service';

describe('ChaildrenServiceService', () => {
  let service: ChaildrenService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChaildrenService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
