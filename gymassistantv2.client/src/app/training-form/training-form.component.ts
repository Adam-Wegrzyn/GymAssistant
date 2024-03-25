import { Component, ElementRef, Input, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Training } from '../domain/Training';
import { CommonModule } from '@angular/common';
import { Weight } from '../my-trainings/weight';
import { TrainingSet } from '../domain/TrainingSet';
import { TrainingService } from '../services/training-service';
import { Exercise } from '../domain/Exercise';

@Component({
  selector: 'app-training-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './training-form.component.html',
  styleUrl: './training-form.component.css'
})
export class TrainingFormComponent implements OnInit {
  @Input() training = new Training();
  @ViewChild('closeBtn') closeBtn: ElementRef;
  @ViewChild('form') form: NgForm;
  @ViewChild('notificationSubmit') notificationSubmit: ElementRef;

 // const btnClose: HTMLButtonElement | null = document.querySelector('btnClose');
  reps: number[] = [];
  weightDecimal: number[] = [];
  weight: Weight = new Weight();
  trainingSet: TrainingSet = new TrainingSet();
  trainingSets: TrainingSet[] = [];
  exercises: Exercise[];
  exercise: Exercise = new Exercise();
  sets: number[] = [];
  submitMessage: string;
  isSuccessMsg: boolean = false;
  isErrorMsg: boolean = false;

  constructor(private trainingService: TrainingService){

  }

  ngOnInit(): void {
    this.trainingService.GetAllExercises().subscribe( (res) =>  this.exercises = res );
    this.initDropDowns();
  }

  private initDropDowns() {
    this.trainingSet.reps = 1;
    for (let i = 1; i <= 100; i++) {
      this.reps.push(i);
    }

    this.trainingSet.sets = 1;
    for (let i = 1; i < 100; i++) {
      this.sets.push(i);
    }
    // if(this.training.id == 0) this.training.trainingSet = [new TrainingSet(new Exercise())];
    
    
  }

  onSubmit(){
   // this.training.trainingSet = this.trainingSets;
    this.trainingService.AddTraining(this.training).subscribe(
      () => this.showSuccessMessage(),
      (err) => this.showErrorMessage(),
      () => {
      this.form.reset();
      this.trainingSets = [];
      }
    );

    

  }
  showErr(err: any): void {
    console.log(err);
  }

  addExercise() {
    let id = this.training.trainingSet[this.training.trainingSet.length - 1].id;
    console.log(this.exercise)
    var trainingSet = new TrainingSet(
      this.training.trainingSet[id].exercise,
      this.training.trainingSet[id].reps,
      this.training.trainingSet[id].sets);
    this.training.trainingSet.push(trainingSet)
    console.log(this.trainingSets)

   
  }
  showSuccessMessage(): void 
  {
    this.isSuccessMsg = true;
    this.isErrorMsg = false;
  }

  showErrorMessage(): void 
  {
    this.isErrorMsg = true;
    this.isSuccessMsg = false;
  }
}




