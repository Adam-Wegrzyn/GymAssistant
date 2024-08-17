import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SetTrainingNameModalComponent } from './set-training-name-modal.component';

describe('SetTrainingNameModalComponent', () => {
  let component: SetTrainingNameModalComponent;
  let fixture: ComponentFixture<SetTrainingNameModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SetTrainingNameModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SetTrainingNameModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
