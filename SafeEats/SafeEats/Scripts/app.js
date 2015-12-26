var app = angular.module('SafeEats', []);

app.controller("SpinController", ["$scope", function ($scope) {
    $scope.test = 'Click the button';

    //$scope.hello = function () {
        
    //    $http.get("api/SafeEatsApi")
    //        .success(function (response) {
    //            console.log(response);
    //            $scope.test = response.Data[1];
    //        })
    //    .error(function (error) { alert(error.message); });

    //}

    $scope.spin = function () {
        
        $http.get("api/SafeEatsApi")

        .success(function (response) {
            console.log(response);
            $scope.recipe = response.Data[0];
        })
    }
}]);