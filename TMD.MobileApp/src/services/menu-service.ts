import { IService } from './IService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/fromPromise';
import { AppSettings } from './app-settings'
import { LoadingService } from './loading-service'
import { Storage } from '@ionic/storage';

@Injectable()
export class MenuService implements IService {

  constructor(private loadingService: LoadingService, private storage: Storage) { }

  getId = (): string => 'menu';

  getTitle = (): string => 'UIAppTemplate';

  getAllThemes = (): Array<any> => {
    return [];
  };

  getDataForTheme = (data: any) => {
    if (!data || !data.MenuRights) {    
      return;
    }

    let pages = [];
    pages.push({ 
      title: 'Home', 
      titleAr: 'الصفحة الرئيسية', 
      component: 'ContentPage',
      icon: 'icon-home'
    });
    let menuRights = JSON.parse(data.MenuRights);
    let rootMenuItems = menuRights.filter((menuRight: any) => menuRight.IsRootItem);
    let childMenuItems = menuRights.filter((menuRight: any) => !menuRight.IsRootItem);
    rootMenuItems.forEach(element => {
        pages.push({ 
          title: element.Name, 
          id: element.MenuId,
          titleAr: element.NameAr,
          icon: element.Icon 
        });  
    });   

    return {
      "RootMenuItems": pages,
      "ChildMenuItems": childMenuItems,
      "UserPreferredLanguage": data.UserPreferredCulture,
      "background": "assets/images/background/16.jpg",
      "image": "assets/images/logo/login-3.png",
      "title": "Ionic3 UI Theme - Blue Light"
    };
  };

  getEventsForTheme = (menuItem: any): any => {
    return {};
  };

  prepareParams = (item: any) => {
    return {
      title: item.title,
      data: {},
      events: this.getEventsForTheme(item)
    };
  };

  load(item: any): Observable<any> {
    var that = this;
    return Observable.fromPromise(that.storage.get('authData').then((data) => {
      return that.getDataForTheme(data);
    }));
  }
}
