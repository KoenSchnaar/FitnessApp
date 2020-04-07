import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Exercise } from "./exercise"
import { Workout } from './workout';

@Injectable()
export class DataService {

    constructor(private http: HttpClient) {

    }

    private token: string = "";
    private tokenExpiration: Date;

    public workout: Workout = new Workout();

    public exercises: Exercise[] = [];

    loadExercises(): Observable<boolean>{
        return this.http.get("/api/exercises")
            .pipe(
                map((data: any[]) => {
                    this.exercises = data;
                    return true;
                }));
    }

    //public get loginRequired(): boolean {
    //    return this.token.length == 0 || this.tokenExpiration > new Date();
    //}

    public checkout() {
        if (!this.workout.name) {
            this.workout.name = "test";
        }
        if (!this.workout.muscleGroup) {
            this.workout.muscleGroup = "test";
        }
        return this.http.post("/api/workouts", this.workout, {
            headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)
        })
            .pipe(map(response => {
                this.workout = new Workout();
                return true;
            }));
    }

    public addToWorkout(newExercise: Exercise) {
        let exercise: Exercise = this.workout.exercises.find(e => e.exerciseId == newExercise.exerciseId);
        if (exercise) {

        }
        else {
            this.workout.exercises.push(newExercise);
        }
    }

    public deleteFromWorkout(pickedExercise: Exercise) {
        let exercise: Exercise = this.workout.exercises.find(e => e.exerciseId == pickedExercise.exerciseId);
        let index: number = this.workout.exercises.findIndex(e => e.exerciseId == pickedExercise.exerciseId);
        if (exercise) {
            this.workout.exercises.splice(index, 1);
        }
        else {
            
        }
    }
}