import { TestBed } from '@angular/core/testing';

import { TopicDataService } from './topic-data.service';

describe('ProjectDataService', () => {
  let service: TopicDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TopicDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
