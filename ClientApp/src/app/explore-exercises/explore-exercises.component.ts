import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IExercise } from 'src/domain/exercise';
import { TrainingService } from '../services/training-service';

@Component({
  selector: 'app-explore-exercises',
  templateUrl: './explore-exercises.component.html',
  styleUrls: ['./explore-exercises.component.css']
})
export class ExploreExercisesComponent implements OnInit {

  sub!: Subscription;
  exercises: IExercise[];

  constructor(private trainingService: TrainingService) { }

  ngOnInit(): void{
    this.sub = this.trainingService.getAllExercises().subscribe(data => {
      this.exercises = data;
    }, error => console.log(error));
    console.log(this.sub);
  }

}
