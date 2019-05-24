import { Component } from '@angular/core';
import { IonicPage, NavParams } from 'ionic-angular';
import { NavController } from 'ionic-angular/navigation/nav-controller';
import { CartService } from '../../services/cart-service';
import { Api } from '../../providers';

@IonicPage()
@Component({
    selector: 'product-details',
    templateUrl: 'product-details.html',
    providers: [CartService]
})
export class ProductDetailPage {
    product: any = {};

    /**
     * Constructor
     */
    constructor(nav: NavParams, private navCtrl: NavController, public api: Api,
        private cartService: CartService) {
        this.product = nav.get("Product") || {};
    }

    openImageSlider = (product: any): any => {
        this.navCtrl.push("ProductDetailsPageFullScreenGallery", {
            'items': product.ProductImages,
            'name': product.Name
        });
    }

    addToCart(product: any, event: any) {
        if (event) {
            event.stopPropagation();
        }
        this.cartService.addToCart(product);
    }
}
