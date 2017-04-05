//ownersController.js
(function () {

    "use strict";

    //create a controller: (getting the existing module)
    angular.module("app-owners")
        .controller("ownersController", ownersController);

    //$http - call to server
    function ownersController($http) {

        //ViewModel
        var vm = this;

        //Array of the db information
        vm.owners = [];

        vm.newOwner = {};
        //Error message
        vm.errorMessage = "";
        vm.isBusy = true;

        //Get information from api get request
        $http.get("api/ownerships")
            .then(function (response) {
                //success
                angular.copy(response.data, vm.owners);
            }, function (error) {
                //failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        //Add owner to database
        vm.addOwner = function () {

            vm.isBusy = true;
            vm.errorMessage = "";
            $http.post("api/ownerships", vm.newOwner)
                .then(function (response) {
                    //success
                    vm.owners.push(response.data);
                    vm.newOwner = {};
                }, function (error) {
                    //failure
                    vm.errorMessage = "Failed to add new owner: " + error;
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };
    };



}());