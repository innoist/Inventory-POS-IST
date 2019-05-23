import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { LoadingHelper } from '../providers/loader/loader';
import { Api } from '../providers';

@Injectable()
export class ProductService {
    constructor(private loadingHelper: LoadingHelper, private api: Api) {
    }

    load(params?: any): Observable<any> {
        var that = this;
        that.loadingHelper.presentLoader();
        var response = that.api.get('api/Product', params).share();
        response.subscribe(snapshot => {
            that.loadingHelper.dismissLoader();
        }, err => {
            console.log("Failed to load products.", err);
            that.loadingHelper.dismissLoader();
        });
        return response;        
    }

    loadCategories(params?: any): Observable<any> {
        var that = this;
        that.loadingHelper.presentLoader();
        var response = that.api.get('api/Product/ByCategory', params).share();
        response.subscribe(snapshot => {
            that.loadingHelper.dismissLoader();
        }, err => {
            console.log("Failed to load products categories.", err);
            that.loadingHelper.dismissLoader();
        });
        return response;        
    }

    loadMainCategories(params?: any): Observable<any> {
        var that = this;
        that.loadingHelper.presentLoader();
        var response = that.api.get('api/Product/MainCategories', params).share();
        response.subscribe(snapshot => {
            that.loadingHelper.dismissLoader();
        }, err => {
            console.log("Failed to load main categories.", err);
            that.loadingHelper.dismissLoader();
        });
        return response;        
    }
}
