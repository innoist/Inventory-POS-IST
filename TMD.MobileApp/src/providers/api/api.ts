import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Http, RequestOptions, Headers, Jsonp } from '@angular/http';
import { Injectable } from '@angular/core';
import { Storage } from '@ionic/storage';

/**
 * Api is a generic REST Api handler. Set your API url first.
 */
@Injectable()
export class Api {
  public url: string = 'http://localhost:23867';
  public token: string = '';
  constructor(public http: HttpClient, private _http: Http, private storage: Storage) {
    this.storage.get('authData').then((data) => {
      if (!this.token && data && data.access_token) {
        this.token = data.access_token;
      }
    }).catch(function () {
      console.log('Failed to fetch token');
    });
  }

  get(endpoint: string, params?: any, reqOpts?: any) {
    if (!reqOpts) {
      reqOpts = {
        params: new HttpParams(),
        headers: new HttpHeaders().set('Content-Type', 'application/json').set('Authorization', `Bearer ${this.token}`)
      };
    }

    // Support easy query params for GET requests
    if (params) {
      reqOpts.params = new HttpParams();
      for (let k in params) {
        reqOpts.params = reqOpts.params.set(k, params[k]);
      }
    }

    return this.http.get(this.url + '/' + endpoint, reqOpts);
  }

  post(endpoint: string, body: any, reqOpts?: any) {
    if (!reqOpts) {
      reqOpts = {
        params: new HttpParams(),
        headers: new HttpHeaders().set('Content-Type', 'application/json').set('Authorization', `Bearer ${this.token}`)
      };
    }
    return this.http.post(this.url + '/' + endpoint, body, reqOpts);
  }

  put(endpoint: string, body: any, reqOpts?: any) {
    if (!reqOpts) {
      reqOpts = {
        params: new HttpParams(),
        headers: new HttpHeaders().set('Content-Type', 'application/json').set('Authorization', `Bearer ${this.token}`)
      };
    }
    return this.http.put(this.url + '/' + endpoint, body, reqOpts);
  }

  delete(endpoint: string, reqOpts?: any) {
    if (!reqOpts) {
      reqOpts = {
        params: new HttpParams(),
        headers: new HttpHeaders().set('Content-Type', 'application/json').set('Authorization', `Bearer ${this.token}`)
      };
    }
    return this.http.delete(this.url + '/' + endpoint, reqOpts);
  }

  patch(endpoint: string, body: any, reqOpts?: any) {
    if (!reqOpts) {
      reqOpts = {
        params: new HttpParams(),
        headers: new HttpHeaders().set('Content-Type', 'application/json').set('Authorization', `Bearer ${this.token}`)
      };
    }
    return this.http.patch(this.url + '/' + endpoint, body, reqOpts);
  }

  login(loginObj) {
    let myHeaders: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded'
    });
    let body = `grant_type=password&username=${loginObj.username}&password=${loginObj.password}`
    return this.http.post(`${this.url}/token`, body, { headers: myHeaders });
  }
}
