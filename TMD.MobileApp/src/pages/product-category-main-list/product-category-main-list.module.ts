import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { TranslateModule } from '@ngx-translate/core';
import { ProductCategoryMainListPage } from './product-category-main-list';
import { AppHeaderModule } from '../../components/header/header.module';


@NgModule({
  declarations: [
    ProductCategoryMainListPage
  ],
  imports: [
    IonicPageModule.forChild(ProductCategoryMainListPage),
    AppHeaderModule,
    TranslateModule.forChild()
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ProductCategoryMainListPageModule {}
