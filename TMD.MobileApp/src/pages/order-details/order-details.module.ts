import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { OrderDetailsPage } from './order-details';
import { AppHeaderModule } from '../../components/header/header.module';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  declarations: [
    OrderDetailsPage,
  ],
  imports: [
    IonicPageModule.forChild(OrderDetailsPage),
    TranslateModule.forChild(),
    AppHeaderModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class OrderDetailsPageModule {}
