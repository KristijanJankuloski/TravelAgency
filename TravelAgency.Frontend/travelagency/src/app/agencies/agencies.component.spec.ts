import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgenciesComponent } from './agencies.component';

describe('AgenciesComponent', () => {
  let component: AgenciesComponent;
  let fixture: ComponentFixture<AgenciesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgenciesComponent]
    });
    fixture = TestBed.createComponent(AgenciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
