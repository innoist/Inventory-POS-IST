import { IService } from './IService';
import { Injectable } from '@angular/core';
import 'rxjs/add/observable/fromPromise';
import { NavController } from 'ionic-angular';

@Injectable()
export class MenuService implements IService {
  
  constructor() { }

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

  load(): any {
    return [
      {
        title: 'Home',
        component: 'ProductCategoryListPage',
        icon: 'icon-home'
      }
    ];
  }
}
