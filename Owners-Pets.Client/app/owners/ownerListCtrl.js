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
    }
}());
