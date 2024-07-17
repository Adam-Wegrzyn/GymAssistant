import { Exercise } from "./Exercise";

export class TrainingSet{
    public id: number;
    public reps: number;
    public sets: number;
    public weight: number;

    constructor(reps: number = 0,  sets: number = 0, weight: number = 0){
        this.id = 0;
        this.sets = sets;
        this.reps = reps;
        this.weight = weight;
    }
}