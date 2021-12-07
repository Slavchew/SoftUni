class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];
        this.totalProfit = 0
        this.currentWorkload = 0
        this.pets = 0
    }


    newCustomer(ownerName, petName, kind, procedures) {
        if (this.pets == this.capacity) {
            throw new Error('Sorry, we are not able to accept more patients!');
        } else {

            let owner = this.clients.find(c => c.name == ownerName)

            if (owner === undefined) {

                owner = {
                    name: ownerName,
                    pets: []
                }
                this.clients.push(owner)
            }

            let pet = owner.pets.find(p => p.name === petName)

            if (pet === undefined || pet.procedures.length == 0) {

                if (pet === undefined) {
                    pet = {
                        name: petName,
                        kind: kind.toLowerCase(),
                        owner: ownerName,
                        procedures: [],
                    }
                    owner.pets.push(pet)
                }
                pet.procedures = procedures
                this.pets++
                this.currentWorkload = (this.pets / this.capacity) * 100
                return `Welcome ${petName}!`
            } else {
                throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${pet.join(', ')}.`);
            }
        }
    }

    onLeaving(ownerName, petName) {
        let owner = this.clients.find(x => x.name == ownerName);
        if (owner === undefined) {
            throw new Error('Sorry, there is no such client!');
        } else {
            let pet = owner.pets.find(p => p.name === petName)

            if (pet === undefined || pet.procedures.length == 0) {
                throw new Error(`Sorry, there are no procedures for  ${petName}!`)
            }

            this.totalProfit += (pet.procedures.length) * 500;
            pet.procedures = [];
            this.pets--;
            this.currentWorkload = (this.pets / this.capacity) * 100;
            return `Goodbye ${petName}. Stay safe!`
        }
    }

    toString() {
        let result = [
            `${this.clinicName} is ${Math.floor(this.currentWorkload)}% busy today!`,
            `Total profit: ${this.totalProfit.toFixed(2)}$`
        ]

        for (const client of this.clients.sort((a, b) => a.name.localeCompare(b.name))) {
            result.push(`${client.name} with:`);

            for (const pet of client.pets.sort((a,b)=> a.name.localeCompare(b.name))) {
                result.push(`---${ pet.name } - a ${ pet.kind } that needs: ${pet.procedures.join(', ')}`);
            }
        }

        return result.join('\n');
    }
}

let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B'])); 
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']); 
console.log(clinic.toString());
