(function () {
    "use strict";

    angular
        .module("ownerManagment")
        .controller("OwnerListCtrl",
        ["ownerResource",
            OwnerListCtrl]);

    function OwnerListCtrl(ownerResource) {
        var vm = this;

        ownerResource.query(function (data) {
            vm.owners = data;
        });

        vm.errorMessage = "";
        //To add owner
        vm.addOwner = function () {

            $http.post("/api/ownerships", vm.newOwner)
                .then(function (response) {
                    //success
                    vm.owners.push(response.data);
                    vm.newOwner = {};
                }, function () {
                    // failure
                    vm.errorMessage = "Failed to save new owner.";
                });
        };
    }
}());
