import { __decorate } from "tslib";
import { Component } from "@angular/core";
let ExerciseList = class ExerciseList {
    constructor(data) {
        this.data = data;
        this.exercises = [];
        (this).exercises = data.exercises;
    }
    ngOnInit() {
        this.data.loadExercises()
            .subscribe(succes => {
            if (succes) {
                this.exercises = this.data.exercises;
            }
        });
    }
    addExercise(exercise) {
        this.data.addToWorkout(exercise);
    }
};
ExerciseList = __decorate([
    Component({
        selector: "exercise-list",
        templateUrl: "./exerciseList.component.html",
        styleUrls: []
    })
], ExerciseList);
export { ExerciseList };
//# sourceMappingURL=exerciseList.component.js.map