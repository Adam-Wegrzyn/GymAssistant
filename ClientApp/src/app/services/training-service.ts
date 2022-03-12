import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import {catchError, tap} from "rxjs/operators";
import { IExercise } from "src/domain/exercise";
import { Test } from "tslint";

@Injectable({
    providedIn:'root'
})

export class TrainingService{

    baseUrl: string;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string){
        this.baseUrl = baseUrl;
    }

    getAllExercises(): Observable<IExercise[]>{
       var test =  this.http.get<any>(this.baseUrl + 'training').pipe(
           tap(data => console.log(data)))
           return test;
       }
       
    
}