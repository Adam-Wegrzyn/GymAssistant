import { Component, OnInit, Pipe } from '@angular/core';
import { TrainingService } from '../services/training-service';
import { Training } from '../domain/Training';
import { TrainingSet } from '../domain/TrainingSet';
import { groupBy } from 'lodash-es';
import { GroupByPipe } from './group-by.pipe';

@Component({
  selector: 'app-training-log',
  templateUrl: './training-log.component.html',
  styleUrls: ['./training-log.component.css']
})
export class TrainingLogComponent implements OnInit {

  constructor(private trainingService: TrainingService) {
  }
  ngOnInit(): void {

    //testing purposes
    this.initTrainings();
   // this.initDropDowns();
    
    this.isSelectedTrainingShown = true;
  }
  // private initDropDowns() {
  //   this.trainingSet.reps = 1;
  //   for (let i = 1; i <= 100; i++) {
  //     this.reps.push(i);
  //   }

  //   this.trainingSet.sets = 1;
  //   for (let i = 1; i < 100; i++) {
  //     this.sets.push(i);
  //   }
  // }

  selectedTraining: Training | undefined;
  trainings: Training[];
  trainingsRows: any = [[]];
  isTrainingSelectVisible: boolean = false;
  isSelectedTrainingShown: boolean = false;
  exercises: any[];
  groupByPipe: GroupByPipe;


  showTrainingSelect(){
    this.initTrainings();
    this.isTrainingSelectVisible = true;
  }
  public initTrainings() {
    this.trainingService.GetAllTrainings().subscribe(
      (res) => this.trainings = res,
      (err) => console.log(err),
      () => {
        this.createTrainingRows()
        //testing purposes
        this.selectedTraining = this.trainings.find(t => t.id == 66);
        console.log(this.selectedTraining)
      }
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
  selectTraining(id: number){
    this.isTrainingSelectVisible = false;
    this.showTrainingLog(id);
  }

  showTrainingLog(id: number) {
    if(this.trainings.find(t => t.id == id) !== undefined){
      this.selectedTraining = this.trainings.find(t => t.id == id);
      
    }
    else{
      throw console.error("This training doesn't exist!");
      
    }
    
    this.isSelectedTrainingShown = true;
  }

  addSet(id: number){
   // this.selectedTraining?.trainingSet.push(new TrainingSet())

  }

}

