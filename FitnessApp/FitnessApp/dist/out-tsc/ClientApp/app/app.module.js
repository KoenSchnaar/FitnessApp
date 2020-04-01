import { __decorate } from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExerciseList } from './Exercises/exerciseList.component';
import { APP_BASE_HREF } from '@angular/common';
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent,
            ExerciseList
        ],
        imports: [
            BrowserModule,
            AppRoutingModule
        ],
        providers: [{ provide: APP_BASE_HREF, useValue: '/' }],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map