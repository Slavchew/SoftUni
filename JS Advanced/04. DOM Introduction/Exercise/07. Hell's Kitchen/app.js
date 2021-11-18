function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = document.querySelector('#inputs>textarea').value;
        
      const arr = JSON.parse(input);
      let restaurants = {};
  
      for (const restaurant of arr) {
          let splittedInput = restaurant.split(' - ');
          let restaurantName = splittedInput[0];
          let workers = splittedInput[1].split(', ')
          let restaurantWorkers = [];
          for (const worker of workers) {
              workerData = worker.split(' ');
  
              let workerName = workerData[0];
              let workerSalary = Number(workerData[1]);
              restaurantWorkers.push({ workerName, workerSalary });
          }
  
          if (restaurants[restaurantName] != undefined) {
              restaurantWorkers.forEach((el) => {
                  restaurants[restaurantName].push(el);
              });
          } else {
              restaurants[restaurantName] = restaurantWorkers;
          }
      }
  
  
  
      let averageSalaries = [];
      let bestSalaries = {};
      for (const [restaurant, workers] of Object.entries(restaurants)) {
          let averageSalary = 0;
          let bestSalary = 0;
          console.log(restaurant);
          console.log(workers);
          for (const worker of Object.values(restaurants[restaurant])) {
              averageSalary += worker.workerSalary;
  
              if (worker.workerSalary > bestSalary) {
                  bestSalary = worker.workerSalary;
              }
          }
  
          averageSalary /= workers.length;
  
          averageSalaries.push({ restaurant, value: averageSalary });
          bestSalaries[restaurant] = bestSalary;
      }
  
      averageSalaries.sort(function (a, b) {
          return b.value - a.value;
      });
  
      let bestRestaurantName = averageSalaries[0].restaurant;
  
      let bestRestaurantText = `Name: ${bestRestaurantName} Average Salary: ${averageSalaries[0].value.toFixed(2)} Best Salary: ${bestSalaries[bestRestaurantName].toFixed(2)}`;
      
      let sortedWorkersBySalary = restaurants[bestRestaurantName];
  
      sortedWorkersBySalary.sort(function (a, b) {
          return b.workerSalary - a.workerSalary;
      });
  
      let workersText = '';
  
      sortedWorkersBySalary.forEach((el) => {
          workersText += `Name: ${el.workerName} With Salary: ${el.workerSalary} `;
      });
  
  
      document.querySelector('#outputs #bestRestaurant > p').textContent = bestRestaurantText;
      document.querySelector('#outputs #workers > p').textContent = workersText;
  }
}
