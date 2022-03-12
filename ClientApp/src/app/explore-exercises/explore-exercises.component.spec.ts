import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExploreExercisesComponent } from './explore-exercises.component';

describe('ExploreExercisesComponent', () => {
  let component: ExploreExercisesComponent;
  let fixture: ComponentFixture<ExploreExercisesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExploreExercisesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExploreExercisesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
