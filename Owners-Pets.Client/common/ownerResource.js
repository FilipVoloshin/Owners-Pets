(function () {
    "use strict";

    angular.module("common.services")
        .factory("ownerResource",
        ["$resource",
            "appSettings",
            ownerResource]);
    function ownerResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/ownerships/:id");
    };

}());