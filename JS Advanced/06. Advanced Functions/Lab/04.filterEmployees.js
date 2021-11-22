function solve(data, criteria) {
    let employees = JSON.parse(data);

    let criteriaSplitted = criteria.split('-');
    let criteriaType = criteriaSplitted[0];
    let criteriaData = criteriaSplitted[1];

    let filtered = employees.filter(x => x[criteriaType] == criteriaData);



    for (let i = 0; i < filtered.length; i++) {
        console.log(`${i}. ${filtered[i].first_name} ${filtered[i].last_name} - ${filtered[i].email}`);
    }
}

solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`, 
'gender-Female'
)

