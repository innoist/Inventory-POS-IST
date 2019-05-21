import { Component } from '@angular/core';
import { IonicPage } from 'ionic-angular';
import { OrderService } from '../../services/order-service';

@IonicPage()
@Component({
    templateUrl: 'order-list.html',
    providers: [OrderService]
})
export class OrderListPage {

    pageSize: number = 10;
    orderStatus: number;
    data: any[] = [];
    orders: any[] = [];
    totalDataCount: number = 0;
    activeInfiniteScroll: any;
    animateClass: any;

    /**
     * Constructor
     */
    constructor(private orderService: OrderService) {
        this.animateClass = { 'fade-in-item': true };
    }

    ngAfterViewInit() {
        setTimeout(() => {
            this.getData();
        }, 1000);
    }

    // Get Data
    getData(callback?: Function) {
        this.orderService.get({ PageNo: this.data.length > 0 ? (this.data.length / this.pageSize) + 1 : 1, 
                PageSize: this.pageSize, IsOnline: 1, IsOpen: this.orderStatus })
        .subscribe(response => {
            for (let i = 0; i < response.Orders.length; i++) {
                this.data.push(response.Orders[i]);
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
            var dataToPush = that.data.slice(that.orders.length);
            for (let i = 0; i < dataToPush.length; i++) {
                setTimeout(function () {
                    that.orders.push(dataToPush[i]);
                }, 200 * i);
            }
        }
    }

    // Filter Orders
    filter() {
        this.data.splice(0);
        this.orders.splice(0);
        this.getData(() => {
            // Reactivate infinite scroll
            if (this.activeInfiniteScroll) {
                this.activeInfiniteScroll.enable(true);
            }
        });  
    }

    // When Scrolled load more orders
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

            this.getData(() => {
                console.log('Async operation has ended');
                infiniteScroll.complete(); 
            });
        }, 500);
    }
}
