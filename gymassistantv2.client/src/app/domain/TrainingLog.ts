import { TrainingSession } from "./TrainingSession";

export class TrainingLog{
    public id: number;
    public date: Date;
    public trainingSession: TrainingSession[];

    constructor(id: number, date: Date, trainingSession: TrainingSession[]){
        this.id = id;
        this.date = date;
        this.trainingSession = trainingSession;
    }
}