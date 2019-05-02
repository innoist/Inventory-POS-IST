import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CallbackPipe } from '../pipes/callback.pipe';

@NgModule({
    declarations: [ CallbackPipe ],
    imports: [ CommonModule ],
    exports: [ CallbackPipe ]
})
export class MainPipeModule { }