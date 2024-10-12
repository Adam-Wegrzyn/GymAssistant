import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Exercise } from '../domain/Exercise';
import { TrainingService } from '../services/training-service';

@Component({
  selector: 'app-exercise-details',
  standalone: true,
  imports: [],
  templateUrl: './exercise-details.component.html',
  styleUrl: './exercise-details.component.css'
})
export class ExerciseDetailsComponent implements OnInit {

  exerciseId: number;
  exercise: Exercise;

  constructor(private route: ActivatedRoute,
    private trainingService: TrainingService
  ) {
  }
  ngOnInit(): void {
  this.route.queryParams.subscribe(params =>{this.exerciseId = params ["id"]; })
  this.trainingService.GetExerciseById(this.exerciseId).subscribe(
    (result) => {
      this.exercise = result;
    }
  )
  }

}
