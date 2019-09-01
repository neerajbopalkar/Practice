// Code goes here
//IIFE

(function(){

var app = angular.module("githubViewer", []);
console.log("in IIFE");

var MainController = function($scope, $http){
	console.log("In main controller");

	$scope.message = "Hello Angular";



	var onUserComplete = function(response){

		console.log("in onUserComplete");

		$scope.user = response.data;

	};

	var onError1 = function(reason){
		$scope.error = "Error occurred: " + reason.statusText;
	};

		$http.get("https://api.github.com/users/neerajbopalkar")
			.then(onUserComplete, onError1);

};

app.controller("MainController", ["$scope", "$http", MainController]);
}());
