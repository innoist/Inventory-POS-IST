import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { IonicPageModule } from 'ionic-angular';
import { ContentPage } from './content';
import { AppHeaderModule } from '../../components/header/header.module';

@NgModule({
  declarations: [
    ContentPage,
  ],
  imports: [
    IonicPageModule.forChild(ContentPage),
    TranslateModule.forChild(),
    AppHeaderModule
  ],
  exports: [
    ContentPage
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class ContentPageModule { }
