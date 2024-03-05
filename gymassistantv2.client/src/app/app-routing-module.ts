import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { MyTrainingsComponent } from './my-trainings/my-trainings.component'
import { TrainingLogComponent } from './training-log/training-log.component';
import { AllExercisesComponent } from './all-exercises/all-exercises.component';
import { AddExerciseComponent } from './add-exercise/add-exercise.component';

const routes: Routes = [
    {
        path: "my-trainings",
        component: MyTrainingsComponent
    },
    {
        path: "training-log",
        component: TrainingLogComponent
    },
    {
        path: "all-exercises",
        component: AllExercisesComponent
    },
    {
        path: "add-exercise",
        component: AddExerciseComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}