import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { TranslateModule } from '@ngx-translate/core';
import { ProductDetailPage } from './product-details';
import { AppHeaderModule } from '../../components/header/header.module';


@NgModule({
  declarations: [
    ProductDetailPage
  ],
  imports: [
    IonicPageModule.forChild(ProductDetailPage),
    AppHeaderModule,
    TranslateModule.forChild()
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ProductDetailPageModule {}
