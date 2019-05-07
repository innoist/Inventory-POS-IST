import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { Product } from './product';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
    declarations: [
        Product,
    ],
    imports: [
        IonicPageModule.forChild(Product),
        TranslateModule.forChild()
    ],
    exports: [
        Product
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ProductModule { }
