import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { LoadingHelper } from '../providers/loader/loader';
import { Api } from '../providers';

@Injectable()
export class OrderService {
    constructor(private loadingHelper: LoadingHelper, private api: Api) {
    }

    get(params?: any): Observable<any> {
        var that = this;
        that.loadingHelper.presentLoader();
        var response = that.api.get('api/Order', params).share();
        response.subscribe(snapshot => {
            that.loadingHelper.dismissLoader();
        }, err => {
            console.log("Failed to get list of orders.", err);
            that.loadingHelper.dismissLoader();
        });
        return response;  
    }

    save(data: any): Observable<any> {
        var that = this;
        that.loadingHelper.presentLoader();
        var response = that.api.post('api/Order', data).share();
        response.subscribe(snapshot => {
            that.loadingHelper.dismissLoader();
        }, err => {
            console.log("Failed to place order.", err);
            that.loadingHelper.dismissLoader();
        });
        return response;        
    }
}
