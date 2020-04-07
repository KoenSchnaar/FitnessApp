import { __decorate } from "tslib";
import { Component } from "@angular/core";
let Login = class Login {
    constructor(data, router) {
        this.data = data;
        this.router = router;
        this.creds = {
            username: "",
            password: ""
        };
    }
    onLogin() {
        // call the login service
    }
};
Login = __decorate([
    Component({
        selector: "login",
        templateUrl: "login.component.html",
        styleUrls: []
    })
], Login);
export { Login };
//# sourceMappingURL=login.component.js.map