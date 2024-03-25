import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { TrainingSession } from '../domain/TrainingSession';
import { Training } from '../domain/Training';
import { Exercise } from '../domain/Exercise';
import { TrainingService } from '../services/training-service';
import { TrainingSet } from '../domain/TrainingSet';
import { Weight } from './weight';
import { NgForm } from '@angular/forms';
import { ViewChild } from '@angular/core'
import { faPen, faTrash } from '@fortawesome/free-solid-svg-icons';
import { TrainingFormComponent } from '../training-form/training-form.component';



@Component({
  selector: 'app-my-trainings',
  templateUrl: './my-trainings.component.html',
  styleUrls: ['./my-trainings.component.css']
})
export class MyTrainingsComponent implements OnInit {

  @ViewChild('f') ngForm : NgForm;

  training: Training = new Training();
  trainings: Training[];
  setCount: number;
  trainingsRows: any = [[]];
  faPen = faPen;
  faTrash = faTrash;

  constructor(private trainingService: TrainingService) {

  }


  ngOnInit(): void {
    this.bindTrainings();
  }

  private bindTrainings() {
    this.trainingService.GetAllTrainings().subscribe(
      (res) => this.trainings = res,
      (err) => console.log(err),
      () => this.createTrainingRows()
    );
  }

  private createTrainingRows() {
    this.trainingsRows = [[]];
    let j = 0;
    for (let i = 0; i < this.trainings.length; i++) {
      if (i != 0 && i % 3 == 0) {
        this.trainingsRows.push([]);
        j++;
      }
      this.trainingsRows[j].push(this.trainings[i]);
    }
  }

  onDelete(training: Training){   
    console.log('delete training')
    this.trainingService.DeleteTraining(training.id).subscribe(
      () => {},
      (err) => console.log(err),
      () => this.bindTrainings()
    );
  }

}
