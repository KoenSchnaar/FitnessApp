import { Component, OnInit } from "@angular/core";
import { DataService } from '../shared/dataService';
import { Exercise } from '../shared/exercise';

@Component({
    selector: "exercise-list",
    templateUrl: "./exerciseList.component.html",
    styleUrls: []
})
export class ExerciseList implements OnInit{
    
    constructor(private data: DataService) {
        (this).exercises = data.exercises;
    }

    public exercises: Exercise[] = [];

    ngOnInit(): void {
        this.data.loadExercises()
            .subscribe(succes => {
                if (succes) {
                    this.exercises = this.data.exercises;
                }
            });
    }

    addExercise(exercise: Exercise) {
        this.data.addToWorkout(exercise);
    }

}