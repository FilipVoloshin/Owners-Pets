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

        vm.newPet = {};
        vm.newOwnerId = {};
        //Error message
        vm.errorMessage = "";
        vm.isBusy = true;

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

        vm.addPet = function () {
            vm.isBusy = true;
            vm.errorMessage = "";
            $http.post("/api/pets/", [vm.newPet , vm.newOwnerId])
                .then(function (response) {
                    //Success
                    vm.pets.push({ PetName: vm.newPet.petName });
                    vm.newPet = {};
                }, function () {
                    //Failure
                    vm.errorMessage = "Failed to add owner:";
                })
                .finally(function () {
                    vm.isBusy = false;
                });

        };
    };



}());