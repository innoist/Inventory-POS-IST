import { Component, ViewChild, Input } from '@angular/core';
import { IonicPage, Content, InfiniteScroll, NavController } from 'ionic-angular';
import { ProductService } from '../../services/product-service';
import { Api } from '../../providers';
import 'rxjs/add/operator/debounceTime';
import { FormControl } from '@angular/forms';
import { CartService } from '../../services/cart-service';

@IonicPage()
@Component({
    selector: 'products',
    templateUrl: 'product.html',
    providers: [ProductService, CartService]
})
export class Product {
    @ViewChild(Content) content: Content;
    @Input() category: any;
    data: any[] = [];
    totalDataCount: number = 0;
    products = [];
    animateClass: any;
    pageSize: number = 10;
    searchTerm: string = "";
    searchInput = new FormControl();
    activeInfiniteScroll: InfiniteScroll;

    constructor(private productService: ProductService, public api: Api, private navCtrl: NavController,
        private cartService: CartService) { 
        this.animateClass = { 'fade-in-item': true };
    }

    ngOnInit(){
        // Get Products
        this.getProducts();        
        // Add throttle to search filter
        this.searchInput
        .valueChanges
        .debounceTime(500)
        .subscribe(value => {
            this.searchTerm = value;
            this.filter();
        });
    }

    // Get Products
    getProducts(callback?: Function) {
        this.productService.load({ PageNo: this.data.length > 0 ? (this.data.length / this.pageSize) + 1 : 1, 
                PageSize: this.pageSize, Name: this.searchTerm, Category: this.category.CategoryId })
        .subscribe(response => {
            for (let i = 0; i < response.Products.length; i++) {
                this.data.push(response.Products[i]);
            }
            this.totalDataCount = response.FilteredCount;
            this.populate();
            if (callback) {
                callback(response);
            }
        });
    }

    // Populates products with fadein animation
    populate() {
        var that = this;
        if (that.data) {
            var dataToPush = that.data.slice(that.products.length);
            for (let i = 0; i < dataToPush.length; i++) {
                setTimeout(function () {
                    that.products.push(dataToPush[i]);
                }, 200 * i);
            }
        }
    }

    // Filter products
    filter() {
        this.data.splice(0);
        this.products.splice(0);
        this.getProducts(() => {
            // Reactivate infinite scroll
            if (this.activeInfiniteScroll) {
                this.activeInfiniteScroll.enable(true);
            }
        });  
    }

    // When Scrolled load more products
    doInfinite(infiniteScroll: any) {
        this.activeInfiniteScroll = infiniteScroll;
        console.log('Begin async operation');

        setTimeout(() => {
            if (this.totalDataCount <= this.data.length) {
                console.log('Async operation has ended');
                infiniteScroll.complete();
                infiniteScroll.enable(false);
                return;
            }

            this.getProducts(() => {
                console.log('Async operation has ended');
                infiniteScroll.complete(); 
            });
        }, 500);
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
