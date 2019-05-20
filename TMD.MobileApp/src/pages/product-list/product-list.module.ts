import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { TranslateModule } from '@ngx-translate/core';
import { ProductListPage } from './product-list';
import { ProductModule } from '../../components/product/product.module';
import { AppHeaderModule } from '../../components/header/header.module';


@NgModule({
  declarations: [
    ProductListPage,
  ],
  imports: [
    IonicPageModule.forChild(ProductListPage),
    ProductModule,
    AppHeaderModule,
    TranslateModule.forChild()
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ProductListPageModule {}
