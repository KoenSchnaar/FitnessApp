import { Exercise } from './exercise';
import * as _ from "lodash";

export class Workout {
    workoutModelId: number;
    name: string;
    muscleGroup: string;
    exercises: Array<Exercise> = new Array<Exercise>();
    highestSets: number;
    dateCreated: Date = new Date();

    get numberOfExercises(): number {
        return this.exercises.length;
    }
}
