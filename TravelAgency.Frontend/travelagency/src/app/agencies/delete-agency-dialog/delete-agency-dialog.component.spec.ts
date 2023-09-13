import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteAgencyDialogComponent } from './delete-agency-dialog.component';

describe('DeleteAgencyDialogComponent', () => {
  let component: DeleteAgencyDialogComponent;
  let fixture: ComponentFixture<DeleteAgencyDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteAgencyDialogComponent]
    });
    fixture = TestBed.createComponent(DeleteAgencyDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
