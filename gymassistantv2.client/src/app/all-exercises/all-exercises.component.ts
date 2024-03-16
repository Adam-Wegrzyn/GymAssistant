
import { Exercise } from '../domain/Exercise';
import { TrainingService } from '../services/training-service';
import { FormsModule } from '@angular/forms';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-all-exercises',
  templateUrl: './all-exercises.component.html',
  styleUrls: ['./all-exercises.component.css']
})
export class AllExercisesComponent implements OnInit{
  private changeDetector: ChangeDetectorRef
  allExercises: Exercise[];
  x: Observable<string>;
  ex: Exercise = new Exercise();

  constructor(private trainingService: TrainingService){
    

  }
  ngOnInit(): void {
    this.bindExercises()
  }
  DeleteExercise(id: number) {
    this.trainingService.DeleteExercise(id).subscribe(
      () => this.bindExercises()
    );
    }

  onSubmit(): void {
    this.trainingService.AddExercise(this.ex).subscribe(() => {
    }, (err) => {
      console.log(err)
    },
    () => {
      console.log('adding complete')
      this.bindExercises();
    }
    );
  }

  bindExercises(): void{
    this.trainingService
    .GetAllExercises().
    subscribe((result: Exercise[]) => {
      this.allExercises = result;
    } )
  }

}
