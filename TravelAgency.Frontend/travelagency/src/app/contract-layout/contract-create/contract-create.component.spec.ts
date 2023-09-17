import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractCreateComponent } from './contract-create.component';

describe('ContractCreateComponent', () => {
  let component: ContractCreateComponent;
  let fixture: ComponentFixture<ContractCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ContractCreateComponent]
    });
    fixture = TestBed.createComponent(ContractCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
