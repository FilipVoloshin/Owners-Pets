(function () {
    "use strict";
    angular
        .module("ownerManagment")
        .controller("OwnerListCtrl",
        OwnerListCtrl);

    function OwnerListCtrl() {
        var vm = this;

        vm.owners = [
            {
                "Name": "Filip",
                "PetsCount": 4
            },
            {
                "Name": "Oksana",
                "PetsCount": 3
            },
            {
                "Name": "Andrey",
                "PetsCount": 1
            },
            {
                "Name": "Valentin",
                "PetsCount": 7
            },
            {
                "Name": "Bamper",
                "PetsCount": 3
            }
        ];
    }
}());
