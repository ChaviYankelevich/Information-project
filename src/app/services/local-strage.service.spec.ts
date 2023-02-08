import { TestBed } from '@angular/core/testing';

import { LocalStrageService } from './local-strage.service';

describe('LocalStrageServiceService', () => {
  let service: LocalStrageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LocalStrageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
