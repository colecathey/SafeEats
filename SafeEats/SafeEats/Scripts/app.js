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

    $scope.recipes = [
        { RecipeName: 'Meatloaf', RecipeCreator: 'Pam', RecipeIngredients: 'Meat, Egg, Peppers, Spice' },
        { RecipeName: 'Stuffed Bellpeppers', RecipeCreator: 'Sue', RecipeIngredients: 'Meat, Cheese, Peppers, Spice' },
        { RecipeName: 'Chicken Noodle Soup', RecipeCreator: 'Pam', RecipeIngredients: 'Chicken, Noodles, Broth, Carrots, Peas' },
        { RecipeName: 'Taco Salad', RecipeCreator: 'Todd', RecipeIngredients: 'Meat, Salad, Tortilla, Spice, Cheese' }
    ]
}]);

//app.controller("ProfileController", ["$scope", "$http", function ($scope, $http) {

//    $scope.userId = 
//    $scope.userRecipeList = []




//}]);