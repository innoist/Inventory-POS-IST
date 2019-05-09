import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { IService } from '../../services/IService';

@IonicPage()
@Component({
    templateUrl: 'product-full-screen-gallery.html'
})
export class ProductDetailsPageFullScreenGallery {
    page: any;
    service: IService;
    params: any = {};

    constructor(public navCtrl: NavController, navParams: NavParams) {
        this.params = {data: {}};
        if (navParams.get('items')) {
            this.params.data.items = navParams.get('items');
            this.params.data.name = navParams.get('name');
        } 
    }
}
