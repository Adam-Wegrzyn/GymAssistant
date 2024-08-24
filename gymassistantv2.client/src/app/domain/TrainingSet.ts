import { Exercise } from "./Exercise";

export class TrainingSet{
    public id: number;
    public reps: number;
    public sets: number;
    public weight: number;
    public isCompleted: boolean;

    constructor(reps: number = 0,  sets: number = 0, weight: number = 0, isCompleted: boolean = false){
        this.id = 0;
        this.sets = sets;
        this.reps = reps;
        this.weight = weight;
        this.isCompleted = isCompleted;
    }
}