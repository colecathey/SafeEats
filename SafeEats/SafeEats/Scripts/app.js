var app = angular.module('SafeEats', []);

app.controller("SpinController", ["$scope", function ($scope) {
    $scope.test = '<ul><li>test</li></ul>';

    $scope.hello = function () {
        $scope.test = "Hello, is it me you're looking for?";
    }
}]);