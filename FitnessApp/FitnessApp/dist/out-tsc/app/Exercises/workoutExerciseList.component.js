import { __decorate } from "tslib";
import { Component } from "@angular/core";
let WorkoutExerciseList = class WorkoutExerciseList {
    //was: 'private data:'
    constructor(data) {
        this.data = data;
    }
    removeExercise(exercise) {
        this.data.deleteFromWorkout(exercise);
    }
};
WorkoutExerciseList = __decorate([
    Component({
        selector: "new-workout",
        templateUrl: "workoutExerciseList.component.html",
        styleUrls: []
    })
], WorkoutExerciseList);
export { WorkoutExerciseList };
//# sourceMappingURL=workoutExerciseList.component.js.map