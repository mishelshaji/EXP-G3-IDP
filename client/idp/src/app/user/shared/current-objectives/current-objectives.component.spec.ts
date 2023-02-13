import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentObjectivesComponent } from './current-objectives.component';

describe('CurrentObjectivesComponent', () => {
  let component: CurrentObjectivesComponent;
  let fixture: ComponentFixture<CurrentObjectivesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ CurrentObjectivesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CurrentObjectivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
