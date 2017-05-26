import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { ModalDirective } from 'ng2-bootstrap/modal';

import { Article, ArticlesService, PagedList } from '../shared/index';

import { IPageChangedEvent } from '../../shared/index';

@Component({
    selector: 'aa-list-articles',
    templateUrl: './list-articles.component.html'
})
export class ListArticlesComponent implements OnInit {
     @ViewChild('detailModal') public detailModal: ModalDirective;

    public articles: Article[] = [];
    public selectedArticle: Article = new Article(-1, '', -1);

    public filters: FormGroup;

    public pageSize: number;
    public totalCount: number;

    private articlesService: ArticlesService;

    constructor(
        articlesService: ArticlesService,
        formBuilder: FormBuilder) {
        this.articlesService = articlesService;

        this.filters = new FormGroup({
            'id': new FormControl(''),
            'description': new FormControl(''),
            'price': new FormControl('')
        });

        this.filters.valueChanges
            .debounceTime(500)
            .distinctUntilChanged()
            .flatMap(response => this.getArticles(1))
            .subscribe(
            response => this.setResponse(response),
            error => alert(error));
    }

    public ngOnInit(): void {
        // empty
    }

    public pageChanged(event: IPageChangedEvent): void {
        this.pageSize = event.itemsPerPage;
        this.getArticles(event.page)
            .subscribe(
            response => this.setResponse(response),
            error => alert(error));
    };

    public showDetailModal(article: Article): void {
        this.selectedArticle = article;
        this.detailModal.show();
    }

    public hideDetailModal(): void {
        this.detailModal.hide();
    }

    private getArticles(pageIndex: number): Observable<PagedList<Article>> {
        const filters: any = this.filters.value;

        return this.articlesService.getArticles(
            {
                pageSize: this.pageSize,
                pageIndex: pageIndex - 1,
                sortColumn: 'id',
                sortOrder: 'asc',
                id: filters.id,
                description: filters.description,
                price: filters.price
            });
    }

    private setResponse(data: PagedList<Article>): void {
        this.totalCount = data.totalCount;
        this.articles = Article.parseCollection(data.items);
    }
}
