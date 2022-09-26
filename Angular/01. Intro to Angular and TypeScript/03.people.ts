abstract class Employee {
    public name: string;
    public age: number;
    public salary: number;
    public tasks: Array<string>;

    constructor(name: string, age: number) {
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }

    public work(): void {
        const currentTask = this.tasks.shift();
        this.tasks.push(currentTask);
        console.log(currentTask);
    }

    public collectSalary(): void {
        console.log(`${this.name} received ${this.getSalary()} this month.`);
    }

    public getSalary(): number {
        return this.salary;
    }
}

class Junior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);
        this.tasks = [`${this.name} is working on a simple task.`]
    }
}

class Senior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);
        this.tasks = [`${this.name} is working on a complicated task.`,
        `${this.name} is taking time off work.`,
        `${this.name} is supervising junior workers.`]
    }
}

class Manager extends Employee {
    public dividend: number;
    constructor(name: string, age: number) {
        super(name, age);

        this.dividend = 0;
        this.tasks = [`${this.name} scheduled a meeting.`,
        `${this.name} is preparing a quarterly report.`]
    }

    public getSalary(): number {
        return this.salary + this.dividend;
    }
}