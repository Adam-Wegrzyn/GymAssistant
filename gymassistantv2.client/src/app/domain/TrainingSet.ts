import { Exercise } from "./Exercise";

export class TrainingSet{
    public id: number;
    public exercise: Exercise;
    public reps: number;
    public weight: number;

    constructor(exercise: Exercise = new Exercise(), reps: number = 0, weight: number = 0){
        this.id = 0;
        this.exercise = exercise;
        this.reps = reps;
        this.weight = weight;
    }
}