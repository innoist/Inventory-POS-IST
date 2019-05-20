import { IonicPage, NavController } from "ionic-angular";
import { Component, Input } from "@angular/core";
import { CartService } from "../../services/cart-service";
import { Events } from "ionic-angular/util/events";

@IonicPage()
@Component({
    selector: "app-header",
    templateUrl: "header.html",
    providers: [CartService]
})
export class AppHeader {
    @Input() title: any;
    public itemsInCart: number; 

    /**
     * Constructor
     */
    constructor(private cartService: CartService, events: Events, private navCtrl: NavController) {        
        // Subscribe to cart changes (if item is added/removed from cart)
        events.subscribe("item_added_to_cart", () => {
            this.getItemsCount();
        });
    }

    ngAfterViewInit() {
        this.getItemsCount();
    }

    // Get Items count from cart
    getItemsCount() {
        // Get Count of items in the cart from cart service
        this.cartService.getItemsCountInCart().subscribe(itemsCount => {
            this.itemsInCart = itemsCount;
        });
    }

    // Go to my cart
    gotoMyCart() {
        this.navCtrl.setRoot("MyCartPage");
    }
}