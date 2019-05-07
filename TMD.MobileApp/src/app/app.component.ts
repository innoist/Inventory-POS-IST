import { Component, ViewChild } from '@angular/core';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { TranslateService } from '@ngx-translate/core';
import { Config, Nav, Platform, Events, MenuController } from 'ionic-angular';
import { Settings, LoadingHelper } from '../providers';
import { Storage } from '@ionic/storage';
import { FirstRunPage, HomePage } from '../pages';
import { MenuService } from '../services/menu-service';

@Component({
  template: `  
    <ion-menu side="left" [content]="content">
    <ion-header header-background-image style="'background-image':'url(assets/icon/toysworldlogo.png)'">
      <ion-thumbnail>
          <img src="assets/icon/toysworldlogo.png">
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
        <button ion-item paddinge-left no-lines item-title *ngFor="let p of pages" (click)="openMenuItem(p)">
          <ion-icon icon-small item-left>
            <i class="icon {{p.icon}}"></i>
          </ion-icon>
          {{p.title}}
        </button>
      </ion-list>
      <ion-list no-margin no-padding *ngIf="selectedMenu && selectedMenu.subMenuItems">
        <button ion-item paddinge-left no-lines item-title *ngFor="let p of selectedMenu.subMenuItems" 
            (click)="openPage(p)" menuToggle>
          {{p.title}}
        </button>
      </ion-list>
      <ion-list no-lines>
        <ion-item>
          <button item-start ion-button icon-only (click)="logout()">
            <ion-icon name="log-out"></ion-icon>
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

  // Menu Items
  pages: any[] = [];

  @ViewChild(Nav) nav: Nav;

  constructor(private translate: TranslateService,
    platform: Platform,
    private settings: Settings,
    private config: Config,
    private statusBar: StatusBar,
    private splashScreen: SplashScreen,
    private events: Events,
    private storage: Storage,
    private loader: LoadingHelper,
    private menuCtrl: MenuController,
    private menuService: MenuService) {
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      this.statusBar.styleDefault();
      this.splashScreen.hide();
      this.initTranslate();      
      // If user is authorized then set menu else go to login page
      this.storage.get('authData').then((data) => {
        if (!data || !data.access_token) {
          this.nav.setRoot(FirstRunPage);
        }
      }).catch(function () {
        this.nav.setRoot(FirstRunPage);
      });
      this.events.subscribe("User_LoggedIn", () => {
        this.initApp();
      });
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
  }

  initApp() {
    this.settings.load();
    this.pages = this.menuService.load();
    this.nav.setRoot(HomePage);
  }

  openMenuItem(page: any) {
    this.selectedMenu = page;
    if (this.selectedMenu.component) {
      // Reset Menu State
      this.selectedMenu = undefined;
      this.menuCtrl.toggle();
      this.openPage(page);
      return;
    }
  }

  openPage(page: any) {
    // Reset the content nav to have just this page
    // we wouldn't want the back button to show in this scenario
    this.nav.setRoot(page.component);
  }

  logout() {
    this.loader.presentLoader(true);
    // log out user and reset the user info
    this.storage.set('authData', "");
    // Navigate to login page
    this.nav.setRoot(this.rootPage);
  }
}
