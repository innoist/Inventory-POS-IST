import { Component } from '@angular/core';
import { IonicPage, MenuController, NavController } from 'ionic-angular';
import { Storage } from '@ionic/storage';

@IonicPage()
@Component({
  selector: 'page-content',
  templateUrl: 'content.html'
})
export class ContentPage {

  data: any = {};
  
  constructor(public navCtrl: NavController, private menu: MenuController, private storage: Storage) { 
  }

}
