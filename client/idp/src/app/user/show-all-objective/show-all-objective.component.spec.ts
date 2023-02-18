import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAllObjectiveComponent } from './show-all-objective.component';

describe('ShowAllObjectiveComponent', () => {
  let component: ShowAllObjectiveComponent;
  let fixture: ComponentFixture<ShowAllObjectiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowAllObjectiveComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowAllObjectiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
