import { Component, Input } from '@angular/core';
import { IonicPage, NavController } from 'ionic-angular';

@IonicPage()
@Component({
    selector: 'login-layout-1',
    templateUrl: 'login.html'
})
export class LoginLayout1 {
    @Input() data: any;
    @Input() events: any;

    public username: string;
    public password: string;
    constructor(private navCtrl: NavController) {

    }

    onEvent = (event: string): void => {
        if (event === "onRegister") {
            // redirect to register page
            this.navCtrl.push("SignupPage");
        }
        else if (this.events[event]) {
            this.events[event]({
                'username': this.username,
                'password': this.password
            });
        }
    }
}
