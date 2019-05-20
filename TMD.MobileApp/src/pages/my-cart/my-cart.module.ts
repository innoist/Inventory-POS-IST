import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { MyCartPage } from './my-cart';
import { AppHeaderModule } from '../../components/header/header.module';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  declarations: [
    MyCartPage,
  ],
  imports: [
    IonicPageModule.forChild(MyCartPage),
    TranslateModule.forChild(),
    AppHeaderModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class MyCartPageModule {}
