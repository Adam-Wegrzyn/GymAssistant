import { Exercise } from "./Exercise";
import { TrainingSet } from "./TrainingSet";

export class TrainingSession{
    public id: number;
    public name: string;
    public trainingPlanId: number;
    public trainingSets: TrainingSet[];  
    

    constructor() {
    this.id = 0;
    this.name = "";
    this.trainingPlanId = 0;
    this.trainingSets = [];
    }
}
