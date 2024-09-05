import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing-module';
import { AppComponent } from './app.component';
import { AllExercisesComponent } from './all-exercises/all-exercises.component';
import { AddExerciseComponent } from './add-exercise/add-exercise.component';
import { MyTrainingsComponent } from './my-trainings/my-trainings.component';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TrainingFormComponent } from './training-form/training-form.component';
import { DeletePopUpComponent } from './shared/delete-pop-up/delete-pop-up.component';
import { GroupByPipe } from './training-log/group-by.pipe';
import { TrainingLogFormComponent } from './training-log/training-log-form.component';
import { SetTrainingNameModalComponent } from './set-training-name-modal/set-training-name-modal.component';
import { TrainingActiveComponent } from './training-active/training-active.component';
import { CalendarModule, CalendarUtils, DateAdapter } from 'angular-calendar';
import { TrainingLogComponent } from './training-log copy/training-log.component';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { ConvertTimePipe } from './convert-time.pipe';


@NgModule({
  declarations: [
    AppComponent,
    AllExercisesComponent,
    AddExerciseComponent,
    MyTrainingsComponent,
    TrainingLogFormComponent,
    SetTrainingNameModalComponent,
    TrainingActiveComponent,
    TrainingLogComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    FontAwesomeModule,
    TrainingFormComponent,
    DeletePopUpComponent,
    GroupByPipe,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory}),
    ConvertTimePipe
  ],
  providers: [
    CalendarUtils,
    TrainingActiveComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
