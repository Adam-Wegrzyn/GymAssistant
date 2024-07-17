import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingLogFormComponent } from './training-log-form.component';

describe('TrainingLogFormComponent', () => {
  let component: TrainingLogFormComponent;
  let fixture: ComponentFixture<TrainingLogFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrainingLogFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainingLogFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
