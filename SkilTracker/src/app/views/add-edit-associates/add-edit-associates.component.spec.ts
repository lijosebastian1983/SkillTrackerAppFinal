import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAssociatesComponent } from './add-edit-associates.component';

describe('AddEditAssociatesComponent', () => {
  let component: AddEditAssociatesComponent;
  let fixture: ComponentFixture<AddEditAssociatesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditAssociatesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditAssociatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
