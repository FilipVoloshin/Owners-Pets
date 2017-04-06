﻿//ownersController.js
(function () {

    "use strict";

    //create a controller: (getting the existing module)
    angular.module("appOwner")
        .controller("petsController", petsController);

    //$http - call to server
    function petsController($http, $routeParams) {

        //ViewModel
        var vm = this;

        vm.name = $routeParams.Name;
        vm.ownerId = $routeParams.ID;

        //Array of the db information
        vm.pets = [];

        vm.newPet = {};
        vm.newOwnerId = {};
        //Error message
        vm.errorMessage = "";
        vm.isBusy = true;
        //Get information from api get request
        $http.get("api/pets/" + vm.ownerId)
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
        //Add pet
        vm.addPet = function () {
            vm.isBusy = true;
            vm.errorMessage = "";
            var Indata = { 'OwnerId': vm.ownerId, 'PetName': vm.newPet.petName };
            $http.post("/api/pets/", Indata)
                .then(function (response) {
                    //Success
                    vm.pets.push({ PetName: vm.newPet.petName });
                    vm.newPet = {};
                }, function () {
                    //Failure
                    vm.errorMessage = "Failed to add pet:";
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

        //Delete Pet
        vm.deletePet = function (id) {
            $http.delete("/api/pets/" + id)
                .then(function (response) {
                    var pets = vm.pets.filter(function (p) {
                        return p.PetId !== id;
                    });
                    vm.pets = pets;
                }, function () {
                    //Failure
                    vm.errorMessage = "Failed to delete pet";
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };
    };



}());