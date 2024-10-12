import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { MyTrainingsComponent } from './my-trainings/my-trainings.component'
import { TrainingLogFormComponent } from './training-log/training-log-form.component';
import { AllExercisesComponent } from './all-exercises/all-exercises.component';
import { AddExerciseComponent } from './add-exercise/add-exercise.component';
import { TrainingActiveComponent } from './training-active/training-active.component';
import { TrainingLogComponent } from './training-log copy/training-log.component';
import { ExerciseDetailsComponent } from './exercise-details/exercise-details.component';

const routes: Routes = [
    {
        path: "my-trainings",
        component: MyTrainingsComponent
    },
    {
        path: "training-log-form",
        component: TrainingLogFormComponent
    },
    {
        path: "all-exercises",
        component: AllExercisesComponent
    },
    {
        path: "add-exercise",
        component: AddExerciseComponent
    },
    {
        path: "training-active",
        component: TrainingActiveComponent
    },
    {
        path: "training-log",
        component: TrainingLogComponent
    },
    {
        path: "exercise-details",
        component: ExerciseDetailsComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}