"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var nomes_service_1 = require("./nomes.service");
describe('NomesService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(nomes_service_1.NomesService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=nomes.service.spec.js.map