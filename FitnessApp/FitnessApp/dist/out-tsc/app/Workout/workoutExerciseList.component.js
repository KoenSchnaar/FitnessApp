import { __decorate } from "tslib";
import { Component } from "@angular/core";
let WorkoutExerciseList = class WorkoutExerciseList {
    //was: 'private data:'
    constructor(data, router) {
        this.data = data;
        this.router = router;
    }
    removeExercise(exercise) {
        this.data.deleteFromWorkout(exercise);
    }
    onCheckout() {
        //if (this.data.loginRequired) {
        //    this.router.navigate(["login"]);
        //}
        //else {
        this.router.navigate(["checkout"]);
        //}
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