(function solve() {
    String.prototype.ensureStart = function (str) {
        if (this.toString().startsWith(str)) {
            return this.toString();
        }
        return str + this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if (this.toString().endsWith(str)) {
            return this.toString();
        }
        return this.toString() + str;
    };

    String.prototype.isEmpty = function () {
        if (this.toString().length == 0) {
            return true;
        }
        return false;
    };

    String.prototype.truncate = function (n) {
        const toStr = this.toString();
        if (toStr.length <= n) {
            return toStr;
        }

        if (toStr.length < 4) {
            let str = toStr.substr(0, toStr.length - n);
            str = str + '.'.repeat(n);
            return str;
        } else {
            const splitted = toStr.split(' ');
            if (splitted.length == 1) {
                return toStr.substr(0, n - 3) + '...';
            } else {
                let result = '';
                for (let i = 0; i < splitted.length; i++) {
                    if (result.length + splitted[i].length <= n - 3) {
                        result += ' ' + splitted[i];
                    } else {
                        return result.trim() + '...';
                    }
                }
                return result + '...';
            }
        }
    };

    String.format = function (str, ...params) {
        let result = str;
        for (let i = 0; i < params.length; i++) {
            result = result.replace(`{${i}}`, params[i]);
        }

        return result;
    }

})();

solve();

let str = 'my string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
console.log(str);
str = String.format('jumps {0} {1}',
    'dog');
console.log(str);

