import { Component } from '@angular/core';
import { IonicPage, NavParams } from 'ionic-angular';

@IonicPage()
@Component({
  templateUrl: 'product-list.html'
})
export class ProductListPage {  
  productCategory: any = {};
  
  /**
   * Constructor
   */
  constructor(nav: NavParams) {
    this.productCategory = nav.get("Category") || {};
  }
}
