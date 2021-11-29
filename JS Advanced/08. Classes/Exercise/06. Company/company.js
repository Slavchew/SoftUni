class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || !position || !department || !salary || salary < 0) {
            throw new Error('Invalid input!');
        }

        if (this.departments[department] == undefined) {
            this.departments[department] = [];
        }

        this.departments[department].push({ name, salary, position });

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        const averageSalaries = [];
        for (const department in this.departments) {

            let departmentAverageSalary = 0;
            for (const employee of this.departments[department]) {
                departmentAverageSalary += employee.salary;
            }

            averageSalaries.push([department, (departmentAverageSalary / this.departments[department].length)]);
        }

        averageSalaries.sort((a, b) => {
            return b[1] - a[1];
        });

        let bestDepartment = averageSalaries[0][0];

        let result = `Best Department is: ${bestDepartment}\n`;
        result += `Average salary: ${(averageSalaries[0][1]).toFixed(2)}\n`;

        const bestDepartmentEmployees = [];
        for (const employee of this.departments[bestDepartment]) {
            bestDepartmentEmployees.push([employee.name, employee.salary, employee.position]);
        }

        bestDepartmentEmployees.sort((a, b) => {
            if (a[1] > b[1]) {
                return -1;
            } else if (a[1] < b[1]) { 
                return 1;
            }

            if (a[0] < b[0]) { 
                return -1;
            } else if (a[0] > b[0]) {
                return 1
            } else {
                return 0;
            }
        });

        
        for (const employee of bestDepartmentEmployees) {
            result += `${employee[0]} ${employee[1]} ${employee[2]}\n`;
        }

        return result.trim();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
