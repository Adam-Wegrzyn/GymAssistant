import { Component, OnInit, Pipe } from '@angular/core';
import { TrainingService } from '../services/training-service';
import { Training } from '../domain/Training';
import { TrainingSet } from '../domain/TrainingSet';
import { CalendarEvent } from 'angular-calendar';
import { startOfDay } from 'date-fns';
import { CalendarUtils } from 'angular-calendar'; 
import { TrainingLog } from '../domain/TrainingLog';
import { MatCalendar, MatCalendarCell, MatCalendarCellCssClasses } from '@angular/material/datepicker'
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { faPen, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-training-log',
  templateUrl: './training-log.component.html',
  styleUrls: ['./training-log.component.css']
})
export class TrainingLogComponent implements OnInit {
  events: CalendarEvent[] = [];
  trainingLogs: TrainingLog[] = []
  faPen = faPen;
  faTrash = faTrash;
  viewDate: Date = new Date();
  activeDayIsOpen: boolean = false;
  selectedTrainingLog: TrainingLog;
  selectedTrainingDayLogs: TrainingLog[];
  selectedTraining: Training;
  selectedDay: Date;
  events2: Date[] = [
    new Date(2024, 9, 16), // October 16, 2023
    new Date(2023, 9, 18)  // October 18, 2023
  ];



  constructor(private trainingService: TrainingService) {
  }
  ngOnInit(): void {
    
    this.initTrainings();
  }

  private initTrainings() {
    this.trainingService.GetAllTrainingLogs().subscribe(
      (res) => {
        this.trainingLogs = res;
        this.selectedTrainingLog = this.trainingLogs.sort((a, b) => a.date > b.date ? -1 : 1)[0];   
        this.selectedTraining = this.selectedTrainingLog.training;    
        this.selectedTrainingDayLogs = this.trainingLogs.sort((a, b) => a.date > b.date ? -1 : 1).filter(x => new Date(x.date).toLocaleDateString() == new Date().toLocaleDateString());
        console.log(this.selectedTrainingDayLogs);
      },
      (err) => console.log(err)
    );
  }
 

  dateClass = (date: Date): MatCalendarCellCssClasses => {
    return this.trainingLogs.some(log => new Date(log.date).toLocaleDateString() === date.toLocaleDateString()) ? 'special-date' : '';}

 onSelect(event: any){
  this.selectedDay = event;
  console.log(event);
  console.log(this.trainingLogs);
  //  this.selectedTrainingLog = this.trainingLogs.find(x => x.date == event.date);
  //  this.selectedTraining = this.selectedTrainingLog.training;
  this.selectedTrainingDayLogs = this.trainingLogs.filter(x => new Date(x.date).toLocaleDateString() == event.toLocaleDateString());
  console.log(this.selectedTrainingDayLogs);
 }
}

