var app = angular.module('SafeEats', []);

app.controller("SpinController", ["$scope", function ($scope) {
    $scope.test = "Hello World!";

    $scope.hello = function () {
        $scope.test = "Hello, is it me you're looking for?";
    }
}]);