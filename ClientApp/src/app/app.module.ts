import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TrainingComponent } from './training/training.component';
import { AddExerciseComponent } from './add-exercise/add-exercise.component';
import { ExploreExercisesComponent } from './explore-exercises/explore-exercises.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    TrainingComponent,
    AddExerciseComponent,
    ExploreExercisesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'training', component: TrainingComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'add-exercise', component: AddExerciseComponent },
      { path: 'explore-exercises', component: ExploreExercisesComponent },
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
