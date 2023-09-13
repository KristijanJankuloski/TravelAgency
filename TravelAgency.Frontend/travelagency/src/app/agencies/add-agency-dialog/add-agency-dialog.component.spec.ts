import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAgencyDialogComponent } from './add-agency-dialog.component';

describe('AddAgencyDialogComponent', () => {
  let component: AddAgencyDialogComponent;
  let fixture: ComponentFixture<AddAgencyDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddAgencyDialogComponent]
    });
    fixture = TestBed.createComponent(AddAgencyDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
