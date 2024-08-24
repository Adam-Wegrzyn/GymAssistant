import { TrainingSession } from "./TrainingSession";
import { TrainingSet } from "./TrainingSet";
import { trainingSetExercise } from "./trainingSetExercise";

export class Training{
    public id: number;
    public name: string;
    public trainingSetExercise: trainingSetExercise[];
    public isLogged: boolean;

    constructor(id: number = 0, name: string = '', trainingSetExercise: trainingSetExercise[] = [], isLogged: boolean = false){
        this.id = id,
        this.name = name;
        this.trainingSetExercise = trainingSetExercise;
        this.isLogged = isLogged;
    }
}