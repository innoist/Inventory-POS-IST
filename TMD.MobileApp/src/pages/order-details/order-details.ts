import { Component, ViewChild } from '@angular/core';
import { IonicPage, Content, NavController } from 'ionic-angular';
import { CartService } from '../../services/cart-service';
import { Api } from '../../providers';
import { ToastService } from '../../services/toast-service';

@IonicPage()
@Component({
    selector: 'order-details',
    templateUrl: 'order-details.html',
    providers: [CartService]
})
export class OrderDetailsPage {
    @ViewChild(Content)
    content: Content;
    items: any;
    totalPrice: number = 0;

    constructor(private cartService: CartService, public api: Api, private navCtrl: NavController, 
        private toastService: ToastService) { }

    ngAfterViewInit() {
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

    // Continue with order processing
    proceed() {
        // Add order through api
        // Show success toastr
        this.toastService.presentToast("Your order has been placed successfully.");
        // Reset Cart and redirect to products page
        this.cartService.reset();
        this.navCtrl.setRoot("ProductCategoryListPage");
    }
}
