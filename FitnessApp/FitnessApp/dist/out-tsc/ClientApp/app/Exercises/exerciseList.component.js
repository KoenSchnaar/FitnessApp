import { __decorate } from "tslib";
import { Component } from "@angular/core";
let ExerciseList = class ExerciseList {
    constructor() {
        this.exercises = [{
                name: "first one",
                muscleGroup: "chest"
            }, {
                name: "second one",
                muscleGroup: "back"
            }, {
                name: "third one",
                muscleGroup: "legs"
            }];
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