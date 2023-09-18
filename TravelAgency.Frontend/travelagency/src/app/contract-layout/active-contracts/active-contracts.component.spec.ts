import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveContractsComponent } from './active-contracts.component';

describe('ActiveContractsComponent', () => {
  let component: ActiveContractsComponent;
  let fixture: ComponentFixture<ActiveContractsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ActiveContractsComponent]
    });
    fixture = TestBed.createComponent(ActiveContractsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
