import { TrainingSession } from "./TrainingSession";

export class TrainingPlan{
    public id?: number;
    public name: string;
    public trainingSessions: TrainingSession[];

    constructor(){
        this.id = 0,
        this.name = "";
        this.trainingSessions = [];
    }
}