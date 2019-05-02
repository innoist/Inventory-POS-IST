import { IService } from './IService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ToastService } from './toast-service'
import { LoadingService } from './loading-service'
import { TranslateService } from '@ngx-translate/core';
import { User } from '../providers/user/user';
import { LoadingHelper } from '../providers/loader/loader';

@Injectable()
export class LoginService implements IService {
    loginErrorString: string = "";
    constructor(private loadingService: LoadingService,
        private toastCtrl: ToastService, private translateService: TranslateService,
        public user: User, private loader: LoadingHelper) {
        this.translateService.get('LOGIN_ERROR').subscribe((value) => {
            this.loginErrorString = value;
        });
    }

    getId = (): string => 'login';

    getTitle = (): string => 'Login pages';

    getAllThemes = (): Array<any> => {
        return [
            { "title": "Login + logo 1", "theme": "layout1" },
            { "title": "Login + logo 2", "theme": "layout2" }
        ];
    };

    getDataForTheme = (menuItem: any): Array<any> => {
        return this[
            'getDataFor' +
            menuItem.theme.charAt(0).toUpperCase() +
            menuItem.theme.slice(1)
        ]();
    };

    getDataForLayout1 = (): any => {
        return {
            "username": "Username",
            "password": "Password",
            "register": "Register",
            "login": "Login",
            "skip": "Skip",
            "logo": "assets/img/appicon.png"
        };
    };

    getDataForLayout2 = (): any => {
        return {
            "username": "Username",
            "password": "Password",
            "register": "Register",
            "login": "Login",
            "skip": "Skip",
            "logo": "assets/images/logo/login.png"
        };
    };

    getEventsForTheme = (menuItem: any): any => {
        var that = this;
        return {
            onLogin: function (params) {
                that.loader.presentLoader();
                that.user.login(params).subscribe((resp) => {
                    // An Event is raised from within user service after successful login
                    // which takes user to HomePage i.e. ContentPage
                    // Do something here if needed  
                    that.loader.dismissLoader();
                }, (err) => {
                    that.loader.dismissLoader();
                    that.toastCtrl.presentToast(that.loginErrorString);
                });
            },
            onRegister: function (params) {
                that.toastCtrl.presentToast('onRegister:' + JSON.stringify(params));
            },
            onSkip: function (params) {
                that.toastCtrl.presentToast('onSkip:' + JSON.stringify(params));
            },
            onFacebook: function (params) {
                that.toastCtrl.presentToast('onFacebook:' + JSON.stringify(params));
            },
            onTwitter: function (params) {
                that.toastCtrl.presentToast('onTwitter:' + JSON.stringify(params));
            },
            onGoogle: function (params) {
                that.toastCtrl.presentToast('onGoogle:' + JSON.stringify(params));
            },
            onPinterest: function (params) {
                that.toastCtrl.presentToast('onPinterest:' + JSON.stringify(params));
            },
        };
    };

    prepareParams = (item: any) => {
        let result = {
            title: item.title,
            theme: item.theme,
            data: {},
            events: this.getEventsForTheme(item)
        };
        result[this.getShowItemId(item)] = true;
        return result;
    };

    getShowItemId = (item: any): string => {
        return this.getId() + item.theme.charAt(0).toUpperCase() + "" + item.theme.slice(1);
    }

    load(item: any): Observable<any> {
        var that = this;
        that.loadingService.show();
        return new Observable(observer => {
            that.loadingService.hide();
            observer.next(this.getDataForTheme(item));
            observer.complete();
        });
    }
}
