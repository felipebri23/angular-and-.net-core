import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { PaginationModule } from 'ng2-bootstrap/ng2-bootstrap';

import { PaginationComponent } from './index';

@NgModule({
    imports: [
        // Angular modules
        CommonModule,
        FormsModule,
        ReactiveFormsModule,

        // 3rd party
        PaginationModule.forRoot()
    ],
    declarations: [
        PaginationComponent
    ],
    exports: [
        PaginationComponent
    ],
    providers: []
})
export class SharedModule { }
