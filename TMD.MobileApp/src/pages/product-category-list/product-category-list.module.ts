import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { TranslateModule } from '@ngx-translate/core';
import { ProductCategoryListPage } from './product-category-list';


@NgModule({
  declarations: [
    ProductCategoryListPage,
  ],
  imports: [
    IonicPageModule.forChild(ProductCategoryListPage),
    TranslateModule.forChild()
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ProductCategoryListPageModule {}
