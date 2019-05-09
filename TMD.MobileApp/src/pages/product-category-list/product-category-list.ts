import { Component } from '@angular/core';
import { IonicPage, InfiniteScroll, NavController } from 'ionic-angular';
import { Api } from '../../providers';
import { ProductService } from '../../services/product-service';

@IonicPage()
@Component({
  selector: 'product-category-list',
  templateUrl: 'product-category-list.html',
  providers: [ProductService]
})
export class ProductCategoryListPage {
  animateClass: any;
  data: any[] = [];
  totalDataCount: number = 0;
  productCategories = [];
  pageSize: number = 10;
  searchTerm: string = "";
  activeInfiniteScroll: InfiniteScroll;

  /**
   * Constructor
   */
  constructor(public api: Api, private productService: ProductService, private nav: NavController) {
    this.animateClass = { 'fade-in-item': true };
    this.getProductCategories();
  }

  // Get Product Categories
  getProductCategories(callback?: Function) {
    this.productService.loadCategories({
      PageNo: this.data.length > 0 ? (this.data.length / this.pageSize) + 1 : 1,
      PageSize: this.pageSize
    }).subscribe(response => {
      for (let i = 0; i < response.ProductCategories.length; i++) {
        this.data.push(response.ProductCategories[i]);
      }
      this.totalDataCount = response.FilteredCount;
      this.populate();
      if (callback) {
        callback(response);
      }
    });
  }

  // Populates product categories with fadein animation
  populate() {
    var that = this;
    if (that.data) {
      var dataToPush = that.data.slice(that.productCategories.length);
      for (let i = 0; i < dataToPush.length; i++) {
        setTimeout(function () {
          that.productCategories.push(dataToPush[i]);
        }, 200 * i);
      }
    }
  }

  // When Scrolled load more product categories
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

      this.getProductCategories(() => {
        console.log('Async operation has ended');
        infiniteScroll.complete();
      });
    }, 500);
  }

  // View All products in the specified category
  viewAllProducts(productCategory: any){
    this.nav.push("ProductListPage", { "Category": productCategory });
  }
}
