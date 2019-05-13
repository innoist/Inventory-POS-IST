import { Component, ViewChild } from '@angular/core';
import { IonicPage, Content, FabButton } from 'ionic-angular';
import { CartService } from '../../services/cart-service';
import { Api } from '../../providers';

@IonicPage()
@Component({
    selector: 'my-cart',
    templateUrl: 'my-cart.html',
    providers: [CartService]
})
export class MyCartPage {
    @ViewChild(Content)
    content: Content;
    @ViewChild(FabButton)
    fabButton: FabButton;
    items: any;
    totalPrice: number = 0;

    constructor(private cartService: CartService, public api: Api) { }

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
}
