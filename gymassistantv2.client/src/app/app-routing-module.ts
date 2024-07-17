import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { MyTrainingsComponent } from './my-trainings/my-trainings.component'
import { TrainingLogFormComponent } from './training-log/training-log-form.component';
import { AllExercisesComponent } from './all-exercises/all-exercises.component';
import { AddExerciseComponent } from './add-exercise/add-exercise.component';

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
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}