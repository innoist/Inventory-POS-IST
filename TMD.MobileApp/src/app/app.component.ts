import { Component, ViewChild } from '@angular/core';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { TranslateService } from '@ngx-translate/core';
import { Config, Nav, Platform, Events, MenuController } from 'ionic-angular';
import { Settings, LoadingHelper } from '../providers';
import { Storage } from '@ionic/storage';
import { FirstRunPage, HomePage } from '../pages'; 
import { Api } from '../providers/api/api';
import { MenuService } from '../services/menu-service';
import { ToastService } from '../services/toast-service';

@Component({
  template: `
  
    <ion-menu *ngIf="defaultLanguage === 'en'" side="left" [content]="content">
    <ion-header header-background-image [ngStyle]="{'background-image': 'url(' + menuHeaderParams.background + ')'}">
      <ion-thumbnail>
          <img [src]="menuHeaderParams.image">
      </ion-thumbnail>
      <ion-buttons start *ngIf="selectedMenu" >
        <button ion-button icon-only (click)="selectedMenu = undefined">
          <ion-icon icon-small item-left name="arrow-back"></ion-icon>
        </button>
      </ion-buttons>
      <h2 item-title text-center>{{ "MENU_TITLE" | translate }}</h2>
    </ion-header>
    <ion-content main-menu>
      <ion-list no-margin no-padding *ngIf="!selectedMenu">
        <button ion-item paddinge-left no-lines item-title *ngFor="let p of pages" (click)="openSubMenu(p)">
          <ion-icon icon-small item-left>
            <i class="icon {{p.icon}}"></i>
          </ion-icon>
          {{p.title}}
        </button>
      </ion-list>
      <ion-list no-margin no-padding *ngIf="selectedMenu">
        <button ion-item paddinge-left no-lines item-title *ngFor="let p of subPages" (click)="openPage(p)" menuToggle>
          {{p.title}}
        </button>
      </ion-list>
      <ion-list no-lines>
        <ion-item>
          <button item-start ion-button icon-only (click)="logout()">
            <ion-icon name="log-out"></ion-icon>
          </button>
          <button item-end ion-button icon-left (click)="updateUserCulturePreference('ar')">
            <ion-icon name="globe" md="md-globe"></ion-icon>
            AR
          </button>
        </ion-item>
      </ion-list>      
    </ion-content>
  </ion-menu>
  <ion-menu *ngIf="defaultLanguage === 'ar'" side="right" [content]="content">
    <ion-header header-background-image [ngStyle]="{'background-image': 'url(' + menuHeaderParams.background + ')'}">
      <ion-thumbnail>
          <img [src]="menuHeaderParams.image">
      </ion-thumbnail>
      <ion-buttons start *ngIf="selectedMenu" >
        <button ion-button icon-only (click)="selectedMenu = undefined">
          <ion-icon name="arrow-back"></ion-icon>
        </button>
      </ion-buttons>
      <h2 item-title text-center>{{ "MENU_TITLE" | translate }}</h2>
    </ion-header>
    <ion-content main-menu>
      <ion-list no-margin no-padding *ngIf="!selectedMenu">
        <button ion-item paddinge-left no-lines item-title  *ngFor="let p of pages" (click)="openSubMenu(p)">
          <ion-icon icon-small item-left>
            <i class="icon {{p.icon}}"></i>
          </ion-icon>
          {{p.titleAr}}
        </button>
      </ion-list>
      <ion-list no-margin no-padding *ngIf="selectedMenu">
        <button ion-item paddinge-left no-lines item-title  *ngFor="let p of subPages" (click)="openPage(p)" menuToggle>
          {{p.titleAr}}
        </button>
      </ion-list>
      <ion-list no-lines>
        <ion-item>
          <button item-start ion-button icon-only (click)="logout()">
            <ion-icon name="log-out"></ion-icon>
          </button>
          <button item-end ion-button icon-left (click)="updateUserCulturePreference('en')">
            <ion-icon name="globe" md="md-globe"></ion-icon>
            EN
          </button>
        </ion-item>
      </ion-list>      
    </ion-content>
   </ion-menu>
   <ion-nav #content [root]="rootPage" main swipeBackEnabled="false"></ion-nav>
 `, 
 providers: [MenuService]
})
export class MyApp {
  
  rootPage: string = FirstRunPage;

  selectedMenu: any;

  defaultLanguage: string = "en";

  // Modules - Main Category Menu Items
  pages: any[] = [];

  // Sub Categories - Menu Items
  subPages: any[] = [];

  childMenuItems: any[] = [];

  @ViewChild(Nav) nav: Nav;

  menuHeaderParams: any = { image: "", background: "" };

  updateCultureErrorString: string = "";

  constructor(private translate: TranslateService, 
    private platform: Platform, 
    private settings: Settings, 
    private config: Config, 
    private statusBar: StatusBar, 
    private splashScreen: SplashScreen,
    private events: Events,
    private storage: Storage,
    private loader: LoadingHelper,
    private menuCtrl: MenuController,
    private api: Api,
    private toastCtrl: ToastService,
    private menuService: MenuService) {
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    });
    this.initTranslate();    
    this.events.subscribe("User_LoggedIn", () => {
      this.initApp();        
    });
  }

  initTranslate() {
    // Set the default language for translation strings, and the current language.
    this.translate.setDefaultLang('en');
    const browserLang = this.translate.getBrowserLang();

    if (browserLang) {
      if (browserLang === 'zh') {
        const browserCultureLang = this.translate.getBrowserCultureLang();

        if (browserCultureLang.match(/-CN|CHS|Hans/i)) {
          this.translate.use('zh-cmn-Hans');
        } else if (browserCultureLang.match(/-TW|CHT|Hant/i)) {
          this.translate.use('zh-cmn-Hant');
        }
      } else {
        this.translate.use(this.translate.getBrowserLang());
      }
    } else {
      this.translate.use('en'); // Set your language here
    }

    this.translate.get(['BACK_BUTTON_TEXT']).subscribe(values => {
      this.config.set('ios', 'backButtonText', values.BACK_BUTTON_TEXT);
    });

    this.translate.get(['USER_PREFERRED_LANGUAGE_UPDATE_ERROR']).subscribe(values => {
      this.updateCultureErrorString = values.USERPREFERREDLANGUAGEUPDATE_ERROR;
    });
  }

  initApp(){
    this.menuService.load(null).subscribe(snapshot => {
      if(!snapshot){
        return;
      }
      this.menuHeaderParams = snapshot;
      this.pages = snapshot.RootMenuItems;
      this.childMenuItems = snapshot.ChildMenuItems;
      this.nav.setRoot(HomePage);  
      if(snapshot.UserPreferredCulture && snapshot.UserPreferredCulture !== "en"){
        this.changeLanguage(snapshot.UserPreferredCulture);
      }
    });
    this.settings.load();
  }

  openSubMenu(page){
    this.selectedMenu = page;
    if(this.selectedMenu.component){
      // Reset Menu State
      this.selectedMenu = undefined;
      this.menuCtrl.toggle();
      this.openPage(page);   
      return;
    }

    // Reset Child Menu
    this.subPages = [];
    this.childMenuItems.filter((element) => element.ParentMenuId === this.selectedMenu.id).forEach(element => {
      this.subPages.push({ 
        title: element.Name, 
        component: element.Component,
        titleAr: element.NameAr,
        icon: element.Icon
       });  
    });
  }

  openPage(page){
    // Reset the content nav to have just this page
    // we wouldn't want the back button to show in this scenario
    this.nav.setRoot(page.component);
  }

  logout(){
    this.loader.presentLoader(true);
    // log out user and reset the user info
    this.storage.set('authData', "");
    // Navigate to login page
    this.nav.setRoot("WelcomePage");
  }  

  updateUserCulturePreference(language){
    this.loader.presentLoader();
    this.api.post('api/UserPreferenceApi', { MobileCulture: language }).subscribe((response) => {
      this.changeLanguage(language);
      this.loader.dismissLoader();
    }, (error) => {
      this.loader.dismissLoader();      
      this.toastCtrl.presentToast(this.updateCultureErrorString);
    });
  }

  changeLanguage(language){
    this.menuCtrl.enable(false);
    this.defaultLanguage = language;
    if(language === "ar"){
      this.platform.setDir('rtl', true);
    }
    else{
      this.platform.setDir('ltr', true);
    }    
    this.translate.use(language);
    this.translate.get(['BACK_BUTTON_TEXT']).subscribe(values => {
      this.config.set('ios', 'backButtonText', values.BACK_BUTTON_TEXT);
    });
  }
}
