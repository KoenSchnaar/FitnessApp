import { Component } from "@angular/core";
import { DataService } from '../shared/dataService';
import { Exercise } from '../shared/exercise';
import { Router } from '@angular/router';

@Component({
    selector: "new-workout",
    templateUrl: "workoutExerciseList.component.html",
    styleUrls: []    
})

export class WorkoutExerciseList {
    //was: 'private data:'
    constructor(public data: DataService, private router: Router) { }

    removeExercise(exercise: Exercise) {
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
}