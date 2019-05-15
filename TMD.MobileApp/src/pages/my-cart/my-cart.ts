import { Component, ViewChild } from '@angular/core';
import { IonicPage, Content, FabButton, NavController } from 'ionic-angular';
import { CartService } from '../../services/cart-service';
import { Api } from '../../providers';
import { LoginService } from '../../services/login-service';
import { Storage } from '@ionic/storage';

@IonicPage()
@Component({
    selector: 'my-cart',
    templateUrl: 'my-cart.html',
    providers: [CartService, LoginService]
})
export class MyCartPage {
    @ViewChild(Content)
    content: Content;
    @ViewChild(FabButton)
    fabButton: FabButton;
    items: any;
    totalPrice: number = 0;

    constructor(private cartService: CartService, public api: Api, private navCtrl: NavController,
        private loginService: LoginService, private storage: Storage) { }

    delete = (item: any): void => {
    }

    ngAfterViewInit() {
        this.content.ionScroll.subscribe((d) => {
            this.fabButton.setElementClass("fab-button-out", d.directionY == "down");
        });
        // Load items from cart service (items added to cart)
        this.cartService.getItemsInCart().subscribe(value => {
            this.items = value;
            this.calculateTotalPrice();
        });
    }

    // Calculate Total Price
    calculateTotalPrice() {
        this.items.forEach((item: any) => {
            this.totalPrice += item.Quantity * item.SalePrice;
        });
    }

    // Proceed to checkout
    proceed() {
        this.storage.get('authData').then((data) => {
            if (data && data.access_token) {
                this.navCtrl.setRoot("OrderDetailsPage");
            }
            else {
                this.gotoLoginPage();
            }
        }).catch(function () {
            console.log('Failed to fetch token');
            this.gotoLoginPage();
        });
    }

    // Go to login page
    gotoLoginPage() {
        this.navCtrl.push("ItemDetailsPageLogin", {
            service: this.loginService,
            page: { "theme": "layout1", "title": "Login" }
        });
    }
}
