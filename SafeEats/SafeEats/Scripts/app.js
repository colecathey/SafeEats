var app = angular.module('SafeEats', []);

app.controller("SpinController", ["$scope", "$http", function ($scope, $http) {

    
    $scope.spin = function () {
        
        $http.get("api/SafeEatsApi")

        .success(function (response) {
            console.log(response);
            $scope.randomSpin = Math.random();
            $scope.recipe = response.Data[$scope.randomSpin];

            
            //return random recipe.
            return $scope.recipe;

        })
        .error(function (error) { alert(error.message); });
    }
}]);

//app.controller("ProfileController", ["$scope", "$http", function ($scope, $http) {

//    $scope.userId = 
//    $scope.userRecipeList = []




//}]);