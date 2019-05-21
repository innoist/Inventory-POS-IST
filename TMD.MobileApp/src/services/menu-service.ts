import { IService } from './IService';
import { Injectable } from '@angular/core';
import 'rxjs/add/observable/fromPromise';
import { NavController } from 'ionic-angular';
import { Observable } from 'rxjs/Observable';
import { Storage } from '@ionic/storage';

@Injectable()
export class MenuService implements IService {
  
  constructor(private storage: Storage) { }

  getId = (): string => 'menu';

  getTitle = (): string => 'Menu Service';

  getAllThemes = (): Array<any> => {
    throw new Error("Method not implemented.");
  };
  
  getEventsForTheme(menuItem: any, navCtrl: NavController): any[] {
    throw new Error("Method not implemented.");
  }

  prepareParams(menuItem: any, navCtrl: NavController) {
    throw new Error("Method not implemented.");
  }

  load(): Observable<any> {
    var menu = [
      {
        title: 'Home',
        component: 'ProductCategoryListPage',
        icon: 'icon-home'
      }
    ];

    return Observable.fromPromise(this.storage.get("authData").then(data => {
      if(data && data.access_token){
        menu.push({ 
          title: 'My Orders',
          component: 'OrderListPage',
          icon: 'icon-table'
        });
      }

      return menu;
    }));
  }
}
