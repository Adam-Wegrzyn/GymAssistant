import { Component, ElementRef, Input, OnInit, Pipe, Renderer2, ViewChild } from '@angular/core';
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
import { SetTrainingNameModalComponent } from '../set-training-name-modal/set-training-name-modal.component';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { interval, map } from 'rxjs';
import { TrainingLog } from '../domain/TrainingLog';
import { TrainingActiveComponent } from '../training-active/training-active.component';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-training-log-form',
  templateUrl: './training-log-form.component.html',
  styleUrls: ['./training-log-form.component.css']
})
export class TrainingLogFormComponent implements OnInit {
  @ViewChild('modalExercise') modalExercise: ElementRef;
  @ViewChild('closeBtn') closeBtn: ElementRef;
  @ViewChild('SetTrainingNameModalComponent') setTrainingNameModalComponent: SetTrainingNameModalComponent;
  //@ViewChild('TrainingActiveComponent') trainingActiveComponent: TrainingActiveComponent;
  
  @Input() durationOfTraining: number;
  @Input() isActive: boolean = false;
  isNew: boolean = false;
  form: FormGroup;
  selectedTraining: Training | undefined;
  trainings: Training[];
  trainingId: number;
  repsDropDown: number[] = [];
  exercises: Exercise[];
  isErrorMsg: boolean = false;
  isSuccessMsgEdit: boolean = false;
  isErrorMsgEdit: boolean = false;
  newTrainingName: string;
  modalRef: NgbModalRef;
  countSets: number = 0;
  showCountSets: string;
  showTimer: string;
  currentTime: Date;
  faTimes = faTimes;


  constructor(private modalService: NgbModal,
    private trainingService: TrainingService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private el: ElementRef,
    private renderer: Renderer2,
    private trainingActiveComponent: TrainingActiveComponent) {
  }
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => { this.trainingId = params["id"]; })
    if (this.trainingId == 0) this.isNew = true;
    this.initDropDown();
    this.form = this.fb.group({
      id: this.selectedTraining?.id,
      name: [this.selectedTraining?.name],
      trainingSetExercise: this.fb.array([
      ]),
      isCompleted: false,
      duration: '0'
    })
    

    this.trainingService.GetAllTrainings()
      .subscribe(
        (res) => this.trainings = res,
        (err) => console.log(err),
        () => {
          this.selectedTraining = this.trainings.find(t => t.id == this.trainingId);
          this.populateTrainingSetGroup();
          if (this.isNew) {
            this.showModal();
          }
          this.trainingSetExerciseArr.controls.forEach((element => {
          }));
          console.log(this.form);
          this.form.get('name')?.setValue(this.selectedTraining?.name);
        }
      )

    this.trainingService.GetAllExercises()
      .subscribe(
        (res) => this.exercises = res
      )
  }

  initDropDown() {
    let i = 0
    while (i <= 100) {
      i++
      this.repsDropDown.push(i)
    }
  }

  get trainingSetExerciseArr(): FormArray {
    return this.form.get('trainingSetExercise') as FormArray;
  }
  getTrainingSetArr(id: number): FormArray {
    return <FormArray>this.trainingSetExerciseArr.controls[id].get('trainingSets');
  }



  populateTrainingSetGroup() {
    console.log(this.selectedTraining)
    this.selectedTraining?.trainingSetExercise.forEach(t => {
      console.log(t.exercise.name)
      this.trainingSetExerciseArr.push(this.fb.group({
        id: t.id,
        exercise: t.exercise,
        trainingSets: this.populateTrainingSet(t)
      }))
    });
  }

  populateTrainingSet(trainingSetGroup: trainingSetExercise) {
    const arr = new FormArray<FormGroup>([]);


    trainingSetGroup.trainingSets.forEach(t => {
      arr.push(new FormGroup({
        id: new FormControl(t.id),
        reps: new FormControl<number>(t.reps),
        weight: new FormControl<number>(t.weight),
        isCompleted: new FormControl<boolean>(t.isCompleted)
      }))
    })
    return arr
  }

  addSet(id: number) {
    this.getTrainingSetArr(id).push(this.fb.group({
      reps: 0,
      weight: 0,
      isCompleted: false
    }))
  }

  deleteSet(arrId: number, setId) {
    this.getTrainingSetArr(arrId).removeAt(setId);
  }

  addExercise(id: string) {

    let exercise;
    this.trainingService.GetExerciseById(Number(id))
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

  deleteExercise(id: number) {
    this.trainingSetExerciseArr.removeAt(id);
  }

  onSubmit() {
    if (this.isNew) {
      this.form.value['id'] = 0
      this.trainingService.AddTraining(this.form.value).subscribe();
    }
    else if(this.isActive){
      //consider only completed sets, set id to 0 (to add new records)
      this.trainingSetExerciseArr.controls.forEach(control => {
        const id = control.get('id');
        if (id != null) id.setValue(0);

        const trainingSets: FormArray<any> = control.get('trainingSets') as FormArray<any>;
        if(trainingSets != null){
          for(let i = 0; i < trainingSets.length; i++){
            trainingSets.at(i).value.id = 0;
            if(!trainingSets.at(i).value.isCompleted){
              trainingSets.removeAt(i);
              i--;
            }
          }
        }
      });
      const training = new Training(0, this.form.value['name'], this.form.value['trainingSetExercise'], true);
      const trainingLog = new TrainingLog(0, new Date(), training, this.durationOfTraining)
      this.form.value['id'] = 0
      this.form.value['name'] = this.selectedTraining?.name;
      this.trainingService.AddTrainigLog(trainingLog).subscribe();
    }
    else {
      this.form.value['id'] = this.selectedTraining?.id;
      this.form.value['name'] = this.selectedTraining?.name;
    }


    this.trainingService.UpdateTraining(this.form.value).subscribe(
      () => this.showSuccessMessageEdit(),
      (err) => this.showErrorMessage()
    );

  }
  showErrorMessage(): void {
    this.isErrorMsg = true;
    this.isSuccessMsgEdit = false;
  }
  showSuccessMessageEdit(): void {
    this.isSuccessMsgEdit = true;
    this.isErrorMsgEdit = false;
  }
  showModal(): void {
    this.modalRef = this.modalService.open(SetTrainingNameModalComponent);
    //this.open(this.setTrainingNameModalComponent);
    this.modalRef.componentInstance.name.subscribe((name: string) => {
      console.log(name);
      this.form.value['name'] = name;
      this.form.get('name')?.setValue(name);
      console.log(this.form);
    });
  }

  test(i: number, j: number) {
    this.trainingActiveComponent.setComplete(i, j);
  }
}
