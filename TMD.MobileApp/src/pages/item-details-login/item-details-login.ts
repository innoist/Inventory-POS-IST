import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

import { IService } from '../../services/IService';
import { MenuController } from 'ionic-angular/components/app/menu-controller';

@IonicPage()
@Component({
  templateUrl: 'item-details-login.html'
})
export class ItemDetailsPageLogin {

  page: any;
  service: IService;
  params: any = {};

  constructor(public navCtrl: NavController, navParams: NavParams, private menu: MenuController) {
    // If we navigated to this page, we will have an item available as a nav param
    this.page = navParams.get('page');
    this.service = navParams.get('service');
    if (this.service) {
      this.params = this.service.prepareParams(this.page, navCtrl);
      this.params.data = this.service.load(this.page);
    } else {
      navCtrl.setRoot("ContentPage");
    }		
    
  }
  
  ionViewDidEnter() {
    // the root left menu should be disabled on the tutorial page
    this.menu.enable(false);
  }

  ionViewWillLeave() {
    // enable the root left menu when leaving the tutorial page
    this.menu.enable(true);
  }

}
