import { Component, ElementRef, OnInit, Pipe, ViewChild } from '@angular/core';
import { TrainingService } from '../services/training-service';
import { Training } from '../domain/Training';
import { TrainingSet } from '../domain/TrainingSet';
import { GroupByPipe } from './group-by.pipe';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { trainingSetExercise } from '../domain/trainingSetExercise';
import { Weight } from '../my-trainings/weight';
import { Exercise } from '../domain/Exercise';
@Component({
  selector: 'app-training-log-form',
  templateUrl: './training-log-form.component.html',
  styleUrls: ['./training-log-form.component.css']
})
export class TrainingLogFormComponent implements OnInit {
  @ViewChild('modalExercise') modalExercise: ElementRef;
  @ViewChild('closeBtn') closeBtn: ElementRef;

  form: FormGroup;
  selectedTraining: Training | undefined;
  trainings: Training[];
  trainingId: number;
  repsDropDown: number[] = [];
  exercises: Exercise[];

  constructor(private trainingService: TrainingService, private fb: FormBuilder, private route: ActivatedRoute) {
  }
  ngOnInit(): void {
    this.route.queryParams.subscribe(params =>{this.trainingId = params ["id"]; })

    this.initDropDown();
    this.form = this.fb.group({
      id: this.selectedTraining?.id,
      name: [this.selectedTraining?.name],
      trainingSetExercise: this.fb.array([
      ])
    })

    this.trainingService.GetAllTrainings()
    .subscribe(
      (res) => this.trainings = res,
      (err) => console.log(err),
      () => {
        this.selectedTraining = this.trainings.find(t => t.id = this.trainingId);
        this.populateTrainingSetGroup();  
        this.trainingSetExerciseArr.controls.forEach((element => {
          console.log(element);
        }));
      }
    )

    this.trainingService.GetAllExercises()
    .subscribe(
      (res) => this.exercises = res
    )
  }

  initDropDown(){
    let i = 0
    while(i <= 100){
      i++
      this.repsDropDown.push(i)
    }
  }
  
  get trainingSetExerciseArr(): FormArray{
    return this.form.get('trainingSetExercise') as FormArray;
  }
  getTrainingSetArr(id: number):FormArray {
    return <FormArray>this.trainingSetExerciseArr.controls[id].get('trainingSets');
  }



  populateTrainingSetGroup(){
    console.log(this.selectedTraining)
    this.selectedTraining?.trainingSetExercise.forEach(t => {
      console.log(t.exercise.name)
      this.trainingSetExerciseArr.push(this.fb.group({
        id: t.id,
        exercise: t.exercise,
       trainingSets: this.populateTrainingSet(t)        
      }) )
    });
  }

  populateTrainingSet(trainingSetGroup: trainingSetExercise){
    const arr = new FormArray<FormGroup> ([]);
   
    
    trainingSetGroup.trainingSets.forEach(t => {
      arr.push( new FormGroup({
        id: new FormControl(t.id),
        reps: new FormControl<number>(t.reps),
        weight: new FormControl<number>(t.weight),
      }))     
      })
    return arr
  }

  addSet(id: number){
    this.getTrainingSetArr(id).push(this.fb.group({
      reps: 0,
      weight: 0
     
    }))
  }

  deleteSet(arrId: number, setId){
    this.getTrainingSetArr(arrId).removeAt(setId);
  }

  addExercise(id: string){
    
    let exercise;
    this.trainingService.GetExercise(Number(id))
    .subscribe(
      (res) => exercise = res,
      (err) => console.log(err),
      () => {
        this.trainingSetExerciseArr.push(this.fb.group({
          exercise: exercise,
          trainingSets: this.fb.array([])
        }))
      }
    );
  }

  deleteExercise(id: number){
    this.trainingSetExerciseArr.removeAt(id);
  }

  onSubmit(){
    this.form.value['id'] = this.selectedTraining?.id;
    this.form.value['name'] = this.selectedTraining?.name;

    this.trainingService.UpdateTraining(this.form.value).subscribe();
    
  }

}
