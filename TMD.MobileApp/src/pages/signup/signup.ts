import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { IonicPage, NavController, ToastController, Events } from 'ionic-angular';
import { User, LoadingHelper } from '../../providers';
import { HomePage } from '../';
import { LoginService } from '../../services/login-service';

@IonicPage()
@Component({
  selector: 'page-signup',
  templateUrl: 'signup.html',
  providers: [LoginService]
})
export class SignupPage {
  // The account fields for the login form.
  // If you're using the username field with or without email, make
  // sure to add it to the type
  account: { username: string, email: string, password: string, address: string } = {
    username: 'Test Human',
    email: 'test@example.com',
    password: 'test',
    address: 'Test address'
  };

  // Our translated text strings
  private signupErrorString: string;
  constructor(public navCtrl: NavController,
    public user: User,
    public toastCtrl: ToastController,
    public translateService: TranslateService,
    private loadingHelper: LoadingHelper,
    private loginService: LoginService,
    event: Events) {
    this.translateService.get('SIGNUP_ERROR').subscribe((value) => {
      this.signupErrorString = value;
    });
    // Subscribe to user_loggedin event
    event.subscribe("User_LoggedIn", () => {
      navCtrl.setRoot("OrderDetailsPage");
    });
  }

  doSignup() {
    // Attempt to login in through our User service
    this.loadingHelper.presentLoader();
    this.user.signup(this.account).subscribe(() => {
      this.loadingHelper.dismissLoader();
      this.loginService.doLogin(this.account);
    }, () => {
      this.loadingHelper.dismissLoader();
      // Unable to sign up
      let toast = this.toastCtrl.create({
        message: this.signupErrorString,
        duration: 3000,
        position: 'top'
      });
      toast.present();
    });
  }
}
