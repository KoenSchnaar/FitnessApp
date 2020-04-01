import { Component } from "@angular/core";

@Component({
    selector: "exercise-list",
    templateUrl: "./exerciseList.component.html",
    styleUrls: []
})
export class ExerciseList {
    public exercises = [{
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