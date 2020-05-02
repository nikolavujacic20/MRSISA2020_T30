"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var environment_1 = require("../environments/environment");
var Variables = /** @class */ (function () {
    function Variables() {
    }
    Variables.getApiEndpoint = function () {
        return environment_1.environment.apiUrl;
    };
    return Variables;
}());
exports.Variables = Variables;
//# sourceMappingURL=variables.js.map