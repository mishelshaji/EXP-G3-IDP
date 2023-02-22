import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminmanagerviewComponent } from './adminmanagerview.component';

describe('AdminmanagerviewComponent', () => {
  let component: AdminmanagerviewComponent;
  let fixture: ComponentFixture<AdminmanagerviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminmanagerviewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminmanagerviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
