import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
    moduleId: module.id,
    selector: 'aa-pagination',
    templateUrl: './pagination.component.html'
})
export class PaginationComponent implements OnInit {

    @Input() public totalCount: number;

    @Output() public pageChanged: EventEmitter<IPageChangedEvent> = new EventEmitter<IPageChangedEvent>(false);

    public pageIndex: number = 1;
    public pageSize: number;
    public pageSizeFilter: FormControl;

    constructor() {
        const pageSize: string = '10';
        this.pageSize = parseInt(pageSize, 10);
        this.pageSizeFilter = new FormControl(pageSize);

        this.pageSizeFilter.valueChanges
            .subscribe(value => {
                this.pageSize = parseInt(value, 10);
                this.pageChanged.next({
                    page: this.pageIndex,
                    itemsPerPage: this.pageSize
                });
            });
    }

    public ngOnInit(): void {
        this.pageChanged.next({
            page: 1,
            itemsPerPage: this.pageSize
        });
    }

    public innerPageChanged(event: IPageChangedEvent): void {
        this.pageChanged.next({
            page: event.page,
            itemsPerPage: event.itemsPerPage
        });
    }

}

export interface IPageChangedEvent {
    itemsPerPage: number;
    page: number;
}
