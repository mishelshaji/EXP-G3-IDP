import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAllIdpComponent } from './show-all-idp.component';

describe('ShowAllIdpComponent', () => {
  let component: ShowAllIdpComponent;
  let fixture: ComponentFixture<ShowAllIdpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowAllIdpComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowAllIdpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
