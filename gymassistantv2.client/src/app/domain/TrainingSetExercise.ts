import { Exercise } from "./Exercise";
import { TrainingSet } from "./TrainingSet";

export class trainingSetExercise{
    public id:  number;
    public exercise: Exercise;
    public trainingSets: TrainingSet[];


    constructor(exercise: Exercise, trainingSets: TrainingSet[] ){
        this.exercise = exercise;
        this.trainingSets = trainingSets;
}
}