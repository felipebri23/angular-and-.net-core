import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { routing } from './app.routing';
import { ArticleModule } from './articles/index';
import { StoreModule } from './stores/index';

import { AppComponent } from './app.component';
import { DefaultComponent } from './default.component';
import { ArticlesService } from './articles/index';
import { StoresService } from './stores/index';

@NgModule({
  declarations: [
    DefaultComponent,
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,

    // app modules and routing
    ArticleModule,
    StoreModule,
    routing
  ],
  providers: [
    ArticlesService,
    StoresService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
