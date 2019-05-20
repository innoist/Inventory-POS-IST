import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { AppHeader } from './header';

@NgModule({
    declarations: [
        AppHeader
    ],
    imports: [
        IonicPageModule.forChild(AppHeader)
    ],
    exports: [
        AppHeader
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class AppHeaderModule { }
