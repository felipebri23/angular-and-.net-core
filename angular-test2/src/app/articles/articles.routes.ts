import { RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

import { ListArticlesComponent } from './list/index';

export const routing: ModuleWithProviders = RouterModule.forChild([
    {
        path: 'articles',
        children: [
            {
                path: '',
                component: ListArticlesComponent
            }
        ]
    }
]);
