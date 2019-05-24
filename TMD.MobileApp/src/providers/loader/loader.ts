import { Loading } from 'ionic-angular/components/loading/loading';
import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { LoadingController } from 'ionic-angular';

@Injectable()
export class LoadingHelper {

    loadingMessage: string;

    loader: any;

    constructor(private translateService: TranslateService, 
        private loadingCtrl: LoadingController){
    }

    presentLoader(shouldDismissAutomatically?: boolean){
        this.translateService.get("LOADING_CONTENT").subscribe((value) => {
            this.loadingMessage = value;  
        });
        this.loader = this.loadingCtrl.create({
            content: this.loadingMessage
        });
        if(shouldDismissAutomatically){
            this.loader.setDuration(3000);
        }
        this.loader.present();
    }

    dismissLoader(){
        this.loader.dismiss();
    }
}