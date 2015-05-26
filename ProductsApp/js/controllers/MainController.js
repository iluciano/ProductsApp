app.controller("MainController", function ($scope, $http) {
    $http.get('api/products').
      success(function (data, status, headers, config) {
          $scope.posts = data;
      }).
      error(function (data, status, headers, config) {
          $scope.posts = "Produto não encontrado!";
      });
});