import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { ProductDetailsPageFullScreenGallery } from './product-full-screen-gallery';
import { FullScreenGalleryModule } from '../../components/full-screen-gallery/full-screen-gallery.module';
import { AppHeaderModule } from '../../components/header/header.module';

@NgModule({
  declarations: [
    ProductDetailsPageFullScreenGallery,
  ],
  imports: [
    IonicPageModule.forChild(ProductDetailsPageFullScreenGallery),
    FullScreenGalleryModule,
    AppHeaderModule
  ],
  exports: [
    ProductDetailsPageFullScreenGallery
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ProductDetailsPageFullScreenGalleryModule {}
