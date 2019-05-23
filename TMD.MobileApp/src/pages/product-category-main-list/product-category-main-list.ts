import { Component } from '@angular/core';
import { IonicPage, NavController } from 'ionic-angular';
import { Api } from '../../providers';
import { ProductService } from '../../services/product-service';

@IonicPage()
@Component({
  selector: 'product-category-main-list',
  templateUrl: 'product-category-main-list.html',
  providers: [ProductService]
})
export class ProductCategoryMainListPage {
  productCategories = [];

  /**
   * Constructor
   */
  constructor(public api: Api, private productService: ProductService, private nav: NavController) {
    this.getProductCategories();
  }

  // Get Product Categories
  getProductCategories() {
    this.productService.loadMainCategories().subscribe(response => {
      this.productCategories = response.ProductMainCategories;
    });
  }

  // Open Product Sub Category
  gotoSubCategory(mainCategory: any){
    this.nav.push("ProductCategoryListPage", { "MainCategory": mainCategory });
  }
}
