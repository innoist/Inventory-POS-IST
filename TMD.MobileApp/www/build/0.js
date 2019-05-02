webpackJsonp([0],{

/***/ 350:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WelcomePageModule", function() { return WelcomePageModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(0);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__ngx_translate_core__ = __webpack_require__(56);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_ionic_angular__ = __webpack_require__(33);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__welcome__ = __webpack_require__(364);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var WelcomePageModule = (function () {
    function WelcomePageModule() {
    }
    WelcomePageModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["J" /* NgModule */])({
            declarations: [
                __WEBPACK_IMPORTED_MODULE_3__welcome__["a" /* WelcomePage */],
            ],
            imports: [
                __WEBPACK_IMPORTED_MODULE_2_ionic_angular__["h" /* IonicPageModule */].forChild(__WEBPACK_IMPORTED_MODULE_3__welcome__["a" /* WelcomePage */]),
                __WEBPACK_IMPORTED_MODULE_1__ngx_translate_core__["b" /* TranslateModule */].forChild()
            ],
            exports: [
                __WEBPACK_IMPORTED_MODULE_3__welcome__["a" /* WelcomePage */]
            ]
        })
    ], WelcomePageModule);
    return WelcomePageModule;
}());

//# sourceMappingURL=welcome.module.js.map

/***/ }),

/***/ 364:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return WelcomePage; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(0);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_ionic_angular__ = __webpack_require__(33);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_login_service__ = __webpack_require__(365);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__providers_api_api__ = __webpack_require__(57);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__ionic_storage__ = __webpack_require__(30);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





/**
 * The Welcome Page is a splash page that quickly describes the app,
 * and then directs the user to create an account or log in.
 * If you'd like to immediately put the user onto a login/signup page,
 * we recommend not using the Welcome page.
*/
var WelcomePage = (function () {
    function WelcomePage(navCtrl, menu, loginService, storage, api) {
        this.navCtrl = navCtrl;
        this.menu = menu;
        this.loginService = loginService;
        this.storage = storage;
        this.api = api;
    }
    WelcomePage.prototype.login = function () {
        // Redirect to Login Page 
        this.navCtrl.push("ItemDetailsPageLogin", {
            service: this.loginService,
            page: { "theme": "layout1", "title": "Login" }
        });
    };
    WelcomePage.prototype.signup = function () {
        this.navCtrl.push('SignupPage');
    };
    WelcomePage.prototype.ionViewDidEnter = function () {
        // the root left menu should be disabled on the landing page
        this.menu.enable(false);
    };
    WelcomePage.prototype.ionViewWillLeave = function () {
        // enable the root left menu when leaving the landing page
        this.menu.enable(true);
    };
    WelcomePage = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'page-welcome',template:/*ion-inline-start:"F:\Users\Waqas Ali\Projects\InventoryPOS\Inventory-POS-IST\TMD.MobileApp\src\pages\welcome\welcome.html"*/'<ion-content scroll="false">\n\n  <div class="splash-bg"></div>\n\n  <div class="splash-info">\n\n    <div class="splash-logo" [ngStyle]="{\'background-image\': \'url(assets/icon/icon.png)\'}"></div>\n\n    <div class="splash-intro">\n\n      {{ \'WELCOME_INTRO\' | translate }}\n\n    </div>\n\n  </div>\n\n  <div padding>\n\n    <button ion-button float-left button-clear-outline round outline (click)="signup()">{{ \'SIGNUP\' | translate }}</button>\n\n    <button ion-button float-left button-clear-outline round outline (click)="login()" class="login">{{ \'LOGIN\' |\n\n      translate }}</button>\n\n  </div>\n\n</ion-content>'/*ion-inline-end:"F:\Users\Waqas Ali\Projects\InventoryPOS\Inventory-POS-IST\TMD.MobileApp\src\pages\welcome\welcome.html"*/,
            providers: [__WEBPACK_IMPORTED_MODULE_2__services_login_service__["a" /* LoginService */]]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1_ionic_angular__["l" /* NavController */], __WEBPACK_IMPORTED_MODULE_1_ionic_angular__["j" /* MenuController */], __WEBPACK_IMPORTED_MODULE_2__services_login_service__["a" /* LoginService */],
            __WEBPACK_IMPORTED_MODULE_4__ionic_storage__["b" /* Storage */], __WEBPACK_IMPORTED_MODULE_3__providers_api_api__["a" /* Api */]])
    ], WelcomePage);
    return WelcomePage;
}());

//# sourceMappingURL=welcome.js.map

/***/ }),

/***/ 365:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LoginService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(0);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__toast_service__ = __webpack_require__(120);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__loading_service__ = __webpack_require__(121);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__ngx_translate_core__ = __webpack_require__(56);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__providers_user_user__ = __webpack_require__(228);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__providers_loader_loader__ = __webpack_require__(229);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var LoginService = (function () {
    function LoginService(loadingService, toastCtrl, translateService, user, loader) {
        var _this = this;
        this.loadingService = loadingService;
        this.toastCtrl = toastCtrl;
        this.translateService = translateService;
        this.user = user;
        this.loader = loader;
        this.loginErrorString = "";
        this.getId = function () { return 'login'; };
        this.getTitle = function () { return 'Login pages'; };
        this.getAllThemes = function () {
            return [
                { "title": "Login + logo 1", "theme": "layout1" },
                { "title": "Login + logo 2", "theme": "layout2" }
            ];
        };
        this.getDataForTheme = function (menuItem) {
            return _this['getDataFor' +
                menuItem.theme.charAt(0).toUpperCase() +
                menuItem.theme.slice(1)]();
        };
        this.getDataForLayout1 = function () {
            return {
                "username": "Username",
                "password": "Password",
                "register": "Register",
                "login": "Login",
                "skip": "Skip",
                "logo": "assets/img/appicon.png"
            };
        };
        this.getDataForLayout2 = function () {
            return {
                "username": "Username",
                "password": "Password",
                "register": "Register",
                "login": "Login",
                "skip": "Skip",
                "logo": "assets/images/logo/login.png"
            };
        };
        this.getEventsForTheme = function (menuItem) {
            var that = _this;
            return {
                onLogin: function (params) {
                    that.loader.presentLoader();
                    that.user.login(params).subscribe(function (resp) {
                        // An Event is raised from within user service after successful login
                        // which takes user to HomePage i.e. ContentPage
                        // Do something here if needed  
                        that.loader.dismissLoader();
                    }, function (err) {
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
        this.prepareParams = function (item) {
            var result = {
                title: item.title,
                theme: item.theme,
                data: {},
                events: _this.getEventsForTheme(item)
            };
            result[_this.getShowItemId(item)] = true;
            return result;
        };
        this.getShowItemId = function (item) {
            return _this.getId() + item.theme.charAt(0).toUpperCase() + "" + item.theme.slice(1);
        };
        this.translateService.get('LOGIN_ERROR').subscribe(function (value) {
            _this.loginErrorString = value;
        });
    }
    LoginService.prototype.load = function (item) {
        var _this = this;
        var that = this;
        that.loadingService.show();
        return new __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__["Observable"](function (observer) {
            that.loadingService.hide();
            observer.next(_this.getDataForTheme(item));
            observer.complete();
        });
    };
    LoginService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["B" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_3__loading_service__["a" /* LoadingService */],
            __WEBPACK_IMPORTED_MODULE_2__toast_service__["a" /* ToastService */], __WEBPACK_IMPORTED_MODULE_4__ngx_translate_core__["c" /* TranslateService */],
            __WEBPACK_IMPORTED_MODULE_5__providers_user_user__["a" /* User */], __WEBPACK_IMPORTED_MODULE_6__providers_loader_loader__["a" /* LoadingHelper */]])
    ], LoginService);
    return LoginService;
}());

//# sourceMappingURL=login-service.js.map

/***/ })

});
//# sourceMappingURL=0.js.map