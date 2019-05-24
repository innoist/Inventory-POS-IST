import { Component, ViewChild } from '@angular/core';
import { IonicPage, Content, NavController } from 'ionic-angular';
import { CartService } from '../../services/cart-service';
import { Api } from '../../providers';
import { ToastService } from '../../services/toast-service';
import { OrderService } from '../../services/order-service';
import { TranslateService } from '@ngx-translate/core';

@IonicPage()
@Component({
    selector: 'order-details',
    templateUrl: 'order-details.html',
    providers: [CartService, OrderService]
})
export class OrderDetailsPage {
    @ViewChild(Content)
    content: Content;
    items: any;
    totalPrice: number = 0;
    orderPlacedSuccessMessage: string = "";

    constructor(private cartService: CartService, public api: Api, private navCtrl: NavController,
        private toastService: ToastService, private orderService: OrderService, 
        transalteService: TranslateService) { 
            transalteService.get('ORDER_PLACED').subscribe(value => {
                this.orderPlacedSuccessMessage = value;
            });
        }

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
        // Place Order
        this.cartService.mapToOrder().then(value => {
            console.log(value);
            this.orderService.save(value).subscribe(() => {
                // Show success toastr
                this.toastService.presentToast(this.orderPlacedSuccessMessage);
                // Reset Cart and redirect to products page
                this.cartService.reset();
                this.navCtrl.setRoot("ProductCategoryListPage");
            });
        });
    }
}
