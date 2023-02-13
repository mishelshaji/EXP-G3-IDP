import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectiveDetailedComponent } from './objective-detailed.component';

describe('ObjectiveDetailedComponent', () => {
  let component: ObjectiveDetailedComponent;
  let fixture: ComponentFixture<ObjectiveDetailedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ ObjectiveDetailedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ObjectiveDetailedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
