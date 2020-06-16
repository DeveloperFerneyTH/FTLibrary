"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var DataService = /** @class */ (function () {
    function DataService(http) {
        this.http = http;
    }
    DataService.prototype.getAllAuthors = function () {
        return this.http.get("/api/Authors/GetAuthors");
    };
    return DataService;
}());
exports.DataService = DataService;
//# sourceMappingURL=data.service.js.map