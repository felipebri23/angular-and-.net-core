import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { ModalModule, AlertModule } from 'ng2-bootstrap/ng2-bootstrap';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { routing } from './stores.routes';

import { SharedModule } from '../shared/shared.module';

import { ListStoresComponent } from './index';

@NgModule({
    imports: [
        SharedModule,
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        routing,

          // 3rd party
        ModalModule.forRoot(),
        AlertModule.forRoot()
    ],
    exports: [],
    declarations: [
        ListStoresComponent
    ],
    providers: []
})
export class StoreModule { }
