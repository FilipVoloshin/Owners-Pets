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

        //To add owner
        vm.newOwner = {};
        vm.addOwner = function () {
            vm.owners.push({ Name: vm.newOwner.name, PetsCount: 0 });
            vm.newOwner = {};
        };
    }
}());
