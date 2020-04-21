import { __decorate } from "tslib";
import { HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { Workout } from './workout';
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        this.token = "";
        this.workout = new Workout();
        this.exercises = [];
    }
    loadExercises() {
        return this.http.get("/api/exercises")
            .pipe(map((data) => {
            this.exercises = data;
            return true;
        }));
    }
    //public get loginRequired(): boolean {
    //    return this.token.length == 0 || this.tokenExpiration > new Date();
    //}
    checkout() {
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
    addToWorkout(newExercise) {
        let exercise = this.workout.exercises.find(e => e.exerciseId == newExercise.exerciseId);
        if (exercise) {
        }
        else {
            this.workout.exercises.push(newExercise);
        }
    }
    deleteFromWorkout(pickedExercise) {
        let exercise = this.workout.exercises.find(e => e.exerciseId == pickedExercise.exerciseId);
        let index = this.workout.exercises.findIndex(e => e.exerciseId == pickedExercise.exerciseId);
        if (exercise) {
            this.workout.exercises.splice(index, 1);
        }
        else {
        }
    }
};
DataService = __decorate([
    Injectable()
], DataService);
export { DataService };
//# sourceMappingURL=dataService.js.map