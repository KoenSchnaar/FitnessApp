import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';

import { DataService } from './shared/dataService';
import { AppComponent } from './app.component';
import { ExerciseList } from './workout/exerciseList.component';
import { WorkoutExerciseList } from "./workout/workoutExerciseList.component";
import { Workout } from "./workout/workout.component";
import { Checkout } from "./checkout/checkout.component";
import { Login } from './login/login.component';
import { APP_BASE_HREF } from '@angular/common';

import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms"

let routes = [
    { path: "", component: Workout },
    { path: "checkout", component: Checkout },
    { path: "login", component: Login }
];

@NgModule({
  declarations: [
        AppComponent,
        ExerciseList,
        WorkoutExerciseList,
        Workout,
        Checkout,
        Login
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(routes, {
          useHash: true,
          enableTracing: false // for debugging of the routes
      }),
    AppRoutingModule
  ],
    providers: [
        DataService,
        { provide: APP_BASE_HREF, useValue: '' }
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
