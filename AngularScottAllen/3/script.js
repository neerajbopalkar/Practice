// Code goes here
//IIFE

(function(){

var app = angular.module("githubViewer", []);
console.log("in IIFE");

var MainController = function($scope, $http){
	console.log("In main controller");

	$scope.message = "github viewer";
  $scope.repoSortOrder = "-stargazers_count";


	var onUserComplete = function(response){

		console.log("in onUserComplete");

		$scope.user = response.data;
    $http.get($scope.user.repos_url)
        .then(onRepos, onError1);

	};

  var onRepos = function(response){
    console.log("on repos received");
    $scope.repos = response.data;
  }

	var onError1 = function(reason){
		$scope.error = "Error occurred: " + reason.statusText;
	};

  $scope.search = function(username){
		$http.get("https://api.github.com/users/" + username)
			.then(onUserComplete, onError1);
  };

  $scope.username = "angular";

};

app.controller("MainController", ["$scope", "$http", MainController]);
}());
