import { Training } from "./Training";

export class TrainingLog{
    public id: number;
    public date: Date;
    public training: Training;
    public duration: number;

    constructor(id: number, date: Date, training: Training, duration: number){
        this.id = id;
        this.date = date;
        this.training = training;
        this.duration = duration;

    }
}