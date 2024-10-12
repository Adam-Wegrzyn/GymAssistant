import { MuscleGroup } from "./Enum";

export class Exercise{
    public id: number;
    public name: string;
    public muscleGroup: MuscleGroup;
    public description: string;
    public imagePath: string;
    public videoPath: string;


    constructor(
        id: number = 0,
        name: string = "",
        muscleGroup: MuscleGroup = MuscleGroup.Chest,
        description: string = "",
        imagePath: string = "",
        videoPath: string = ""
    ) {
        this.id = id;
        this.name = name;
        this.muscleGroup = muscleGroup;
        this.description = description;
        this.imagePath = imagePath;
        this.videoPath = videoPath;
    }
}