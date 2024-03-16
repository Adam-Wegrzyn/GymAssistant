import { TrainingSession } from "./TrainingSession";
import { TrainingSet } from "./TrainingSet";

export class TrainingPlan{
    public id?: number;
    public name: string;
    public trainingSet: TrainingSet[];

    constructor(){
        this.id = 0,
        this.name = "";
        this.trainingSet = [];
    }
}