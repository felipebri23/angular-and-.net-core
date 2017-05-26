import { RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

import { ListStoresComponent } from './list/index';

export const routing: ModuleWithProviders = RouterModule.forChild([
    {
        path: 'stores',
        children: [
            {
                path: '',
                component: ListStoresComponent,
                outlet: 'second-view'
            }
        ]
    }
]);
