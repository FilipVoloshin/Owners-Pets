//ownersController.js
(function () {

    "use strict";

    //create a controller: (getting the existing module)
    angular.module("app-pets")
        .controller("petsController", petsController);

    //$http - call to server
    function petsController($http) {

        //ViewModel
        var vm = this;

        //Array of the db information
        vm.pets = [];

        //Get information from api get request
        $http.get("api/pets/1")
            .then(function (response) {
                //success
                angular.copy(response.data, vm.pets);
            }, function (error) {
                //failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    };



}());