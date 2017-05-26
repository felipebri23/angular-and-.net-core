import { Injectable } from '@angular/core';
import {
    Http,
    Response,
    RequestOptionsArgs,
    RequestOptions,
    Headers,
    URLSearchParams
} from '@angular/http';
import { Observable } from 'rxjs/Rx';

import { Store, PagedList } from './index';

@Injectable()
export class StoresService {

    private baseUrl: string = 'http://localhost:4200/api';
    private http: Http;

    constructor(http: Http) {
        this.http = http;
    }

    public getStores(params?: {}): Observable<PagedList<Store>> {

        let {
            pageSize = 10,
            pageIndex = 0,
            sortColumn = '',
            sortOrder = '',
            id = '',
            name = '',
            city = ''
        }: any = params ? params : {};

        let search: URLSearchParams = new URLSearchParams();
        search.set('pageSize', pageSize.toString());
        search.set('pageIndex', pageIndex.toString());
        if (sortColumn) {
            search.set('sortColumn', sortColumn);
        }
        if (sortOrder) {
            search.set('sortOrder', sortOrder);
        }
        if (id) {
            search.set('id', id);
        }
        if (name) {
            search.set('name', name);
        }
        if (city) {
            search.set('city', city);
        }

        return this.http.get(`${this.baseUrl}/stores`, this.getCommonRequestOption( { search } ))
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response): PagedList<Store> {
        let json: any = res.json();
        let data: PagedList<Store> = new PagedList<Store>();
        data.totalCount = json.totalCount;
        data.items = Store.parseCollection(json.items);
        return data;
    }

    private handleError(error: Response | any): any {
        // In a real world app, you might use a remote logging infrastructure
        console.log(error);
        let errMsg: string;
        if (error instanceof Response) {
            const body: any = error.json() || '';
            const err: any = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

    private getCommonRequestOption(options?: RequestOptionsArgs): RequestOptionsArgs {
        if (options == undefined) {
            options = new RequestOptions();
        }
        if (options.headers == undefined) {
            options.headers = new Headers();
        }

        options.headers.append('Accept', 'application/json');

        return options;
    }
}
