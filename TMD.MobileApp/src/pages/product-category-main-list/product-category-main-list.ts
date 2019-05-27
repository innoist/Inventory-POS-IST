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
      if (!response || !response.ProductMainCategories) {
        return;
      }

      response.ProductMainCategories.forEach((category: any) => {
        category.ImagePath = this.api.url + '/Images/Inventory/' + 
          category.Name.replace(/ /g, '').toLowerCase() + '_main_category.png';
        this.productCategories.push(category);  
      });
    });
  }

  // Open Product Sub Category
  gotoSubCategory(mainCategory: any){
    this.nav.push("ProductCategoryListPage", { "MainCategory": mainCategory });
  }
}
