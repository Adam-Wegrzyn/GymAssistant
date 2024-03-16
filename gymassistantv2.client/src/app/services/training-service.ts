import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TrainingPlan } from "../domain/TrainingPlan";
import { Observable, catchError } from "rxjs";
import { Exercise } from "../domain/Exercise";

@Injectable({
    providedIn: 'root'
})

export class TrainingService{
    public DeleteExercise(id: number) {
      return this.http.delete<Exercise>(this.apiUrl + 'Training/DeleteExercise/' + id)
    }
    private apiUrl = 'https://localhost:7082/'
    constructor (private http: HttpClient){ }

    public GetAllTrainings(): Observable<TrainingPlan[]>{
        return this.http.get<TrainingPlan[]> (this.apiUrl + 'Training/getAllTrainings')
    }
    public GetAllExercises(): Observable<Exercise[]>{
        return this.http.get<Exercise[]>(this.apiUrl + 'Training/getAllExercises')
    }
    public AddTrainingPlan(trainingPlan: TrainingPlan){
        console.log(trainingPlan);
        return this.http.post<TrainingPlan>(this.apiUrl + ('Training/addTraining'),trainingPlan)
    }
    public AddExercise(exercise: Exercise): Observable<Exercise>{
        return this.http.post<Exercise>(this.apiUrl + 'Training/addExercise', exercise)
    }

    
}