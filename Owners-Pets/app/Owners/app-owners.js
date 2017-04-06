// app-owners.js

(function () {

    "use strict";

    //Creating the module
    angular.module("appOwner", ['angularUtils.directives.dirPagination', "ngRoute"])
        .config(function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "petsController",
                controllerAs: "vm",
                templateUrl: "/app/Pets/petsView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });
        });

})(); 