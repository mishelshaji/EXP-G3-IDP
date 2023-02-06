import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentProgressComponent } from './current-progress.component';

describe('CurrentProgressComponent', () => {
  let component: CurrentProgressComponent;
  let fixture: ComponentFixture<CurrentProgressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CurrentProgressComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CurrentProgressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
