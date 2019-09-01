// Code goes here
//IIFE

(function(){

var app = angular.module("githubViewer", []);
console.log("in IIFE");

var MainController = function($scope, $http, $interval, 
	$log, $anchorScroll, $location){
	console.log("In main controller");

	

	var onUserComplete = function(response){

		console.log("in onUserComplete");

		$scope.user = response.data;
    $http.get($scope.user.repos_url)
        .then(onRepos, onError1);

	};

  var onRepos = function(response){
    console.log("on repos received");
    $scope.repos = response.data;
    $location.hash("userdetails");
    $anchorScroll();
  }

	var onError1 = function(reason){
		$scope.error = "Error occurred: " + reason.statusText;
	};

  $scope.search = function(username){
		$http.get("https://api.github.com/users/" + username)
			.then(onUserComplete, onError1);
  };

  $scope.username = "angular";
$scope.message = "github viewer";
  $scope.repoSortOrder = "-stargazers_count";

};

app.controller("MainController", [MainController]);
}());
