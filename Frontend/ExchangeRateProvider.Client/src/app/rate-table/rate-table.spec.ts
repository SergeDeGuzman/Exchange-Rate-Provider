import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RateTable } from './rate-table';

describe('RateTable', () => {
  let component: RateTable;
  let fixture: ComponentFixture<RateTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RateTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RateTable);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
