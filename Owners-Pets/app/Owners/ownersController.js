//ownersController.js
(function () {

    "use strict";

    //create a controller: (getting the existing module)
    angular.module("appOwner")
        .controller("ownersController", ownersController);

    //$http - call to server
    function ownersController($http,$scope) {

        //ViewModel
        var vm = this;

        //Array of the information
        vm.owners = [];

        vm.newOwner = {};
        //Error message
        vm.errorMessage = "";
        vm.isBusy = true;

        //sorting
        $scope.sortColumn = 'Name';
        $scope.reverseSort = false;

        $scope.sortData = function (column) {
            $scope.reverseSort = ($scope.sortColumn == column) ? !$scope.reverseSort : false;
            $scope.sortColumn = column;
        };

        $scope.getSortClass = function (column) {
            if ($scope.sortColumn == column) {
                return $scope.reverseSort ? 'glyphicon glyphicon-chevron-down' : 'glyphicon glyphicon-chevron-up';
            }
            return '';
        };

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
            $http.post("/api/ownerships", vm.newOwner)
                .then(function (response) {
                    //Success
                    vm.owners.push(response.data);
                    vm.newOwner = {};
                }, function () {
                    //Failure
                    vm.errorMessage = "Failed to add owner:";
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

        //Delete owner 
        vm.deleteOwner = function (petId) {
            $http.delete("/api/ownerships/" + petId)
                .then(function (response) {
                    var owners = vm.owners.filter(function (o) {
                        return o.ID !== petId;
                    });
                    vm.owners = owners;
                }, function () {
                    //Failure
                    vm.errorMessage = "Failed to delete owner";
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

    };



}());