
export class TrainingSet{
    public id: number;
    public exerciseId: number;
    public reps: number;
    public weight: number;
    public trainingSessionId: number;

    constructor(){
        this.id = 0;
        this.exerciseId = 0;
        this.reps = 0;
        this.weight = 0;
        this.trainingSessionId = 0;
    }
}