// app-owners.js

(function () {

    "use strict";

    //Creating the module
    angular.module("appOwner", ['angularUtils.directives.dirPagination', "ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "ownersController",
                controllerAs: "vm",
                templateUrl: "app/views/ownersView.html"
            });

            $routeProvider.when("/pet/:Name/:ID", {
                controller: "petsController",
                controllerAs: "vm",
                templateUrl: "app/views/petsView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });

        });

})(); 