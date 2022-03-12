import { Component, OnInit } from '@angular/core';
import { DaysOfWeek } from 'src/domain/daysOfWeek.enum';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.css']
})
export class TrainingComponent implements OnInit {

  constructor() { }

  isExperienceSelected: boolean;
  noOfTrainingDays: number;
  noOfTrainingDaysCounter: Array<number>;

  daysOfWeek: Array<string>;

  counterNoOfDays(i: number){
    return Array(i)
  }

  experienceCalculate(exp: string){
    this.isExperienceSelected = true;
    if (exp == "beginner") this.noOfTrainingDays = 3
    else if (exp == "intermediate") this.noOfTrainingDays = 4
    else this.noOfTrainingDays = 5
    this.noOfTrainingDaysCounter = this.counterNoOfDays(this.noOfTrainingDays);
    return this.noOfTrainingDays;
  }

  ngOnInit() {
    this.daysOfWeek = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"]
    
  }

}
