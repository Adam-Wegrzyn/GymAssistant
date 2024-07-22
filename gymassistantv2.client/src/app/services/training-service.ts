import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Training } from "../domain/Training";
import { Observable, catchError } from "rxjs";
import { Exercise } from "../domain/Exercise";

@Injectable({
    providedIn: 'root'
})

export class TrainingService{
    private apiUrl = 'https://localhost:7082/'
    constructor (private http: HttpClient){ }

    public DeleteTraining(id: number) {
        return this.http.delete<Exercise>(this.apiUrl + 'Training/DeleteTraining/' + id)
    }
    public DeleteExercise(id: number) {
        return this.http.delete<Exercise>(this.apiUrl + 'Training/DeleteExercise/' + id)
    }
    public GetTraining(id: number) {
        throw new Error('Method not implemented.');
    }
    GetExercise(id: number) {
        return this.http.get<Training[]> (this.apiUrl + 'Training/getExercise/' + id)
      }
    public GetAllTrainings(): Observable<Training[]>{
        return this.http.get<Training[]> (this.apiUrl + 'Training/getAllTrainings')
    }
    public GetAllExercises(): Observable<Exercise[]>{
        return this.http.get<Exercise[]>(this.apiUrl + 'Training/getAllExercises')
    }
    public AddTraining(Training: Training){
        console.log(Training);
        return this.http.post<Training>(this.apiUrl + ('Training/addTraining'),Training)
    }
    public AddExercise(exercise: Exercise): Observable<Exercise>{
        return this.http.post<Exercise>(this.apiUrl + 'Training/addExercise', exercise)
    }
    public UpdateTraining(training: Training) {
        return this.http.post<Training>(this.apiUrl + 'Training/UpdateTraining', training);
      }   
}