var app = angular.module('SafeEats', []);

app.controller("SpinController", ["$scope", "$http", function ($scope, $http) {

    
    $scope.spin = function () {
        
        $http.get("api/SafeEatsApi")

        .success(function (response) {
            console.log(response);
            $scope.recipe = response.Data[1];

            //random number from 0 to recipeList.Length picked here
            //return random recipe.

        })
        .error(function (error) { alert(error.message); });
    }
}]);

app.controller("ProfileController", ["$scope", "$http", function ($scope, $http) {

    $scope.userId = 
    $scope.userRecipeList = []




}]);