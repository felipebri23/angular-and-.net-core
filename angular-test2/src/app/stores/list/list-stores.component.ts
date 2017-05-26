import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { ModalDirective } from 'ng2-bootstrap/modal';

import { Store, StoresService, PagedList } from '../shared/index';

import { IPageChangedEvent } from '../../shared/index';

@Component({
    selector: 'aa-list-stores',
    templateUrl: './list-stores.component.html'
})
export class ListStoresComponent implements OnInit {
     @ViewChild('detailModal') public detailModal: ModalDirective;

    public stores: Store[] = [];
    public selectedStore: Store = new Store(-1, '', '');

    public filters: FormGroup;

    public pageSize: number;
    public totalCount: number;

    private storesService: StoresService;

    constructor(
        storesService: StoresService,
        formBuilder: FormBuilder) {
        this.storesService = storesService;

        this.filters = new FormGroup({
            'id': new FormControl(''),
            'name': new FormControl(''),
            'city': new FormControl('')
        });

        this.filters.valueChanges
            .debounceTime(500)
            .distinctUntilChanged()
            .flatMap(response => this.getStores(1))
            .subscribe(
            response => this.setResponse(response),
            error => alert(error));
    }

    public ngOnInit(): void {
        // empty
    }

    public pageChanged(event: IPageChangedEvent): void {
        this.pageSize = event.itemsPerPage;
        this.getStores(event.page)
            .subscribe(
            response => this.setResponse(response),
            error => alert(error));
    };

    public showDetailModal(store: Store): void {
        this.selectedStore = store;
        this.detailModal.show();
    }

    public hideDetailModal(): void {
        this.detailModal.hide();
    }

    private getStores(pageIndex: number): Observable<PagedList<Store>> {
        const filters: any = this.filters.value;

        return this.storesService.getStores(
            {
                pageSize: this.pageSize,
                pageIndex: pageIndex - 1,
                sortColumn: 'id',
                sortOrder: 'asc',
                id: filters.id,
                name: filters.name,
                city: filters.city
            });
    }

    private setResponse(data: PagedList<Store>): void {
        this.totalCount = data.totalCount;
        this.stores = Store.parseCollection(data.items);
    }
}
