import { TestBed } from '@angular/core/testing';

import { InfornationService } from './infornation-service';

describe('InfornationServiceService', () => {
  let service: InfornationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InfornationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
