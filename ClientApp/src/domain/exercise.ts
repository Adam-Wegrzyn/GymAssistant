import { muscleGroup } from "./muscleGroup.enum";
export interface IExercise{
    "id": number,
    "name": string,
    "muscleGroup": muscleGroup,
}