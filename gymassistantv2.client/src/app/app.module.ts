import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing-module';
import { AppComponent } from './app.component';
import { TrainingLogComponent } from './training-log/training-log.component';
import { AllExercisesComponent } from './all-exercises/all-exercises.component';
import { AddExerciseComponent } from './add-exercise/add-exercise.component';
import { MyTrainingsComponent } from './my-trainings/my-trainings.component';
import { FormsModule }   from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    AppComponent,
    TrainingLogComponent,
    AllExercisesComponent,
    AddExerciseComponent,
    MyTrainingsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    FontAwesomeModule  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
