"use strict";
exports.__esModule = true;
var tslib_1 = require("tslib");
var app_component_1 = require("./app.component");
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib_1.__decorate([
        core_1.NgModule({
            imports: [platform_browser_1.BrowserModule],
            declarations: [app_component_1.AppComponent],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map