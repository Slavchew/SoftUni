import { Component } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent {

    constructor(public userService: UserService) { }

    get isLogged(): boolean {
        return this.userService.isLogged;
    }

    loginHandler(): void {
        this.userService.login();
    }

    logoutHandler(): void {
        this.userService.logout();
    }

}
