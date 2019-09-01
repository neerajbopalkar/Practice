// Code goes here
//alert("hi");
	 /*var obj = "enter movie";
	 var test = prompt(obj);
	 console.log("hello world" + test);
	*/	

	//Immediately invoked function expression IIFE
	//To avoid polluting global namespace
	(function() {
	  console.log("in IIFE");
	  
	  var createWorker = function() {
		  console.log("in createworker");
		  
		  var workCount =0;
		  var task1 = function() {
			  workCount+=1;
			  console.log("workcount in task1 = " + workCount);
		  }
		  
		  return {
			  job1: task1
		  }
	  }
		
		var worker = createWorker();
		worker.job1();
		worker.job1();
		worker.job1();
		worker.job1();
	}());