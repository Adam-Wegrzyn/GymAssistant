import { Component, ElementRef, EventEmitter, Input, OnInit, Output, QueryList, ViewChild, ViewChildren } from '@angular/core';
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
  @Input() isEditMode: boolean;
  @Output() refreshView: EventEmitter<any> = new EventEmitter();
  @ViewChild('closeBtn') closeBtn: ElementRef;
  @ViewChild('form') form: NgForm;
  @ViewChild('notificationSubmit') notificationSubmit: ElementRef;

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
  isSuccessMsgEdit: boolean = false;
  isErrorMsgEdit: boolean = false;
  //needed to have independent ngModel
  trainingToEdit: Training;
  header: string;
  

  constructor(private trainingService: TrainingService){

  }

  ngOnInit(): void {
    this.trainingToEdit = JSON.parse(JSON.stringify(this.training));
    this.trainingService.GetAllExercises().subscribe( (res) =>  this.exercises = res );
    this.initDropDowns();

    if(this.isEditMode){
      this.header = "Edit training";
    }
    else{
      this.header = "Add new training"
    }
    
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
  }

  onSubmit(){
    if(this.isEditMode){
      this.trainingService.UpdateTraining(this.trainingToEdit).subscribe(
        () => this.showSuccessMessageEdit(),
        (err) => this.showErrorMessage()
      );
    }
    else{
      this.trainingService.AddTraining(this.trainingToEdit).subscribe(
        () =>this.showSuccessMessage(),
        (err) => this.showErrorMessage(),
        () => {
        this.form.reset();
        this.trainingSets = [];
        }
      );
    }

    

  }
  showErr(err: any): void {
    console.log(err);
  }

  addExercise() {
    var trainingSet = new TrainingSet();
    // this.trainingToEdit.trainingSet.push(trainingSet)

  }

  deleteExercise(index: number){
    // this.trainingToEdit.trainingSet.splice(index,1);
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
  showSuccessMessageEdit(): void 
  {
    this.isSuccessMsgEdit = true;
    this.isErrorMsgEdit = false;
  }

  closeForm(): void{
    this.refreshView.emit();
  }
}




