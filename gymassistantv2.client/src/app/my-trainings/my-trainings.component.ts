import { Component, OnInit } from '@angular/core';
import { TrainingSession } from '../domain/TrainingSession';
import { TrainingPlan } from '../domain/TrainingPlan';
import { Exercise } from '../domain/Exercise';
import { TrainingService } from '../services/training-service';
import { TrainingSet } from '../domain/TrainingSet';


@Component({
  selector: 'app-my-trainings',
  templateUrl: './my-trainings.component.html',
  styleUrls: ['./my-trainings.component.css']
})
export class MyTrainingsComponent implements OnInit {

  trainingPlan: TrainingPlan = new TrainingPlan();
  trainings: TrainingPlan[];
  trainingSession: TrainingSession = new TrainingSession();
  trainingSessions: TrainingSession[];
  exercises: Exercise[];
  showTrainingSession: boolean = false;
  shownTraining: TrainingPlan;
  isSessionVisible = false;
  setCount: number;
  days: number[] = [1, 2, 3, 4, 5, 6, 7];
  days2: string[] = ["1", "2"];
  trainingSet: TrainingSet;


  constructor(private trainingService: TrainingService) {

  }


  ngOnInit(): void {
    // this.trainingService.GetAllTrainingPlans().subscribe( (res) => this.trainings = res );
    this.trainingService.GetAllExercises().subscribe(
      (res) => this.exercises = res
    )

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

  GetTrainings(): void {
    this.trainingService.GetAllTrainingPlans();
  }

  onSubmit() {
    throw new Error('Method not implemented.');
  }
  showSession() {
    this.isSessionVisible = true;
  }

  addExercise(id: string) {
    console.log(id);
    this.trainingSet = new TrainingSet();
    var trainingSession = this.trainingPlan.trainingSessions.find(t => t = this.trainingSession)
    trainingSession?.trainingSets.push(this.trainingSet)
  }
  addTrainingPlan() {
    throw new Error('Method not implemented.');
  }
  addTrainingSession() {
    this.trainingPlan.trainingSessions.push(this.trainingSession)
  }
}
