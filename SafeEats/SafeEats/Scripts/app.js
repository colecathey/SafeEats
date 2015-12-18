var app = angular.module('SafeEats', []);

app.controller("SpinController", ["$scope", function ($scope) {
    $scope.test = 'Click the button';

    $scope.hello = function () {
        $scope.test = "You clicked the button";
    }
}]);