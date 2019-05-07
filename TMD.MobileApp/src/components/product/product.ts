import { Component, ViewChild } from '@angular/core';
import { IonicPage, Content } from 'ionic-angular';
import { ProductService } from '../../services/product-service';
import { Api } from '../../providers';

@IonicPage()
@Component({
    selector: 'products',
    templateUrl: 'product.html',
    providers: [ProductService]
})
export class Product {
    @ViewChild(Content) content: Content;
    data: any;
    totalDataCount: number = 0;
    products = [];
    animateClass: any;
    pageSize: number = 10;

    constructor(private productService: ProductService, public api: Api) { 
        this.animateClass = { 'fade-in-item': true };
        this.getProducts();
    }

    // Get Products
    getProducts(callback?: Function) {
        this.productService.load({ PageNo: this.data ? (this.data.length / this.pageSize) + 1 : 1, 
                PageSize: this.pageSize }).subscribe(response => {
            if (callback) {
                callback(response);
                return;
            }
            this.data = response.Products;
            this.totalDataCount = response.TotalCount;
            this.populate();
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

    // When Scrolled load more products
    doInfinite(infiniteScroll: any) {
        console.log('Begin async operation');

        setTimeout(() => {
            if (this.totalDataCount <= this.data.length) {
                console.log('Async operation has ended');
                infiniteScroll.complete();
                infiniteScroll.enable(false);
                return;
            }

            this.getProducts((response: any) => {
                for (let i = 0; i < response.Products.length; i++) {
                    this.data.push(response.Products[i]);
                }
                this.populate();
                console.log('Async operation has ended');
                infiniteScroll.complete(); 
            });
        }, 500);
    }

}
