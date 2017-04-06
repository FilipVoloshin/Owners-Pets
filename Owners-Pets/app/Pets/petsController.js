//ownersController.js
(function () {

    "use strict";

    //create a controller: (getting the existing module)
    angular.module("appOwner")
        .controller("petsController", petsController);

    //$http - call to server
    function petsController($http,$routeParams) {

        //ViewModel
        var vm = this;

        vm.name = $routeParams.Name;
        vm.id = $routeParams.ID;

        //Array of the db information
        vm.pets = [];

        vm.newPet = {};
        vm.newOwnerId = {};
        //Error message
        vm.errorMessage = "";
        vm.isBusy = true;
        //Get information from api get request
        $http.get("api/pets/" + vm.id)
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
            var Indata = { 'OwnerId': vm.id, 'PetName': vm.newPet };
            $http.post("/api/pets/", Indata)
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