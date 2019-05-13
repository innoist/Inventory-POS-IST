import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { TranslateModule } from '@ngx-translate/core';
import { ProductCategoryListPage } from './product-category-list';
import { AppHeaderModule } from '../../components/header/header.module';


@NgModule({
  declarations: [
    ProductCategoryListPage
  ],
  imports: [
    IonicPageModule.forChild(ProductCategoryListPage),
    AppHeaderModule,
    TranslateModule.forChild()
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ProductCategoryListPageModule {}
