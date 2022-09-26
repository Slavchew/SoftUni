class Employee {
    constructor(name, age) {
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }
    work() {
        const currentTask = this.tasks.shift();
        this.tasks.push(currentTask);
        console.log(currentTask);
    }
    collectSalary() {
        console.log(`${this.name} received ${this.getSalary()} this month.`);
    }
    getSalary() {
        return this.salary;
    }
}
class Junior extends Employee {
    constructor(name, age) {
        super(name, age);
        this.tasks = [`${this.name} is working on a simple task.`];
    }
}
class Senior extends Employee {
    constructor(name, age) {
        super(name, age);
        this.tasks = [`${this.name} is working on a complicated task.`,
            `${this.name} is taking time off work.`,
            `${this.name} is supervising junior workers.`];
    }
}
class Manager extends Employee {
    constructor(name, age) {
        super(name, age);
        this.dividend = 0;
        this.tasks = [`${this.name} scheduled a meeting.`,
            `${this.name} is preparing a quarterly report.`];
    }
    getSalary() {
        return this.salary + this.dividend;
    }
}
