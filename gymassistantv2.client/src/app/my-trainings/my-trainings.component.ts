import { Component, OnInit } from '@angular/core';
import { TrainingSession } from '../domain/TrainingSession';
import { TrainingPlan } from '../domain/TrainingPlan';
import { Exercise } from '../domain/Exercise';
import { TrainingService } from '../services/training-service';
import { TrainingSet } from '../domain/TrainingSet';
import { Weight } from './weight';
import { NgForm } from '@angular/forms';
import { ViewChild } from '@angular/core'



@Component({
  selector: 'app-my-trainings',
  templateUrl: './my-trainings.component.html',
  styleUrls: ['./my-trainings.component.css']
})
export class MyTrainingsComponent implements OnInit {

  @ViewChild('f') ngForm : NgForm;

  trainingPlan: TrainingPlan = new TrainingPlan();
  trainings: TrainingPlan[];
  exercises: Exercise[];
  exercise: Exercise = new Exercise();
  showTrainingSession: boolean = false;
  shownTraining: TrainingPlan;
  isSessionVisible = false;
  setCount: number;
  days: number[] = [1, 2, 3, 4, 5, 6, 7];
  days2: string[] = ["1", "2"];
  trainingSet: TrainingSet = new TrainingSet();
  trainingSets: TrainingSet[] = [];
  reps: number[] = [];
  weightDecimal: number[] = [];
  weight: Weight = new Weight();
  trainingsRows: any = [[]];



  constructor(private trainingService: TrainingService) {

  }


  ngOnInit(): void {
    this.trainingService.GetAllTrainings().subscribe(
    (res) => this.trainings = res,
    (err) => console.log(err),
    () => this.createTrainingRows()
    );

    this.trainingService.GetAllExercises().subscribe( (res) =>  this.exercises = res );

    //initialize dropDowns
    for(let i=1; i<=30; i++){
      this.reps.push(i);
    }

    for(let i=0; i<4; i++){
      this.weightDecimal.push(i*0.25)
    }

  }

  private createTrainingRows() {
    let j = 0;
    for (let i = 0; i < this.trainings.length; i++) {
      if (i != 0 && i % 3 == 0) {
        this.trainingsRows.push([]);
        j++;
      }
      this.trainingsRows[j].push(this.trainings[i]);
    }
  }

  public ExpandTraining(id: number): void {
    console.log('clicked');
    if (this.showTrainingSession == false) {
      this.showTrainingSession = true;
    }
    else {
      this.showTrainingSession = false;
    }
    this.shownTraining = this.trainings.find(t => t.id)!
  }

  addExercise() {
    console.log(this.exercise)
    var trainingSet = new TrainingSet(
      this.exercise,
      this.trainingSet.reps,
      this.weight.CombineWeight());
    this.trainingSets.push(trainingSet)
    console.log(this.trainingSets)

   
  }

  onSubmit(){
    this.trainingSets.forEach((t) => {
      this.trainingPlan.trainingSet.push(t);
    })
    this.trainingService.AddTrainingPlan(this.trainingPlan).subscribe(
      err => (console.log(err))
    );
    this.ngForm.reset();
    this.trainingSet = new TrainingSet();
  }

}
