import { Component } from '@angular/core';
import { IonicPage, MenuController, NavController } from 'ionic-angular';
import { LoginService } from '../../services/login-service';
import { Api } from '../../providers/api/api';
import { Storage } from '@ionic/storage';
/**
 * The Welcome Page is a splash page that quickly describes the app,
 * and then directs the user to create an account or log in.
 * If you'd like to immediately put the user onto a login/signup page,
 * we recommend not using the Welcome page.
*/
@IonicPage()
@Component({
  selector: 'page-welcome',
  templateUrl: 'welcome.html',
  providers: [LoginService]
})

export class WelcomePage {

  constructor(public navCtrl: NavController, public menu: MenuController, private loginService: LoginService,
    private storage: Storage, private api: Api) {

  }

  login() {
    // Redirect to Login Page 
    this.navCtrl.push("ItemDetailsPageLogin", {
      service: this.loginService,
      page: { "theme": "layout1", "title": "Login" }
    });
  }

  signup() {
    this.navCtrl.push('SignupPage');
  }

  ionViewDidEnter() {
    // the root left menu should be disabled on the landing page
    this.menu.enable(false);
  }

  ionViewWillLeave() {
    // enable the root left menu when leaving the landing page
    this.menu.enable(true);
  }
}
