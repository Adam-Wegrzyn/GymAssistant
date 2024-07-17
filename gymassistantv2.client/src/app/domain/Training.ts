import { TrainingSession } from "./TrainingSession";
import { TrainingSet } from "./TrainingSet";
import { trainingSetExercise } from "./trainingSetExercise";

export class Training{
    public id: number;
    public name: string;
    public trainingSetExercise: trainingSetExercise[];

    constructor(){
        this.id = 0,
        this.name = "";
        this.trainingSetExercise = [];
    }
}