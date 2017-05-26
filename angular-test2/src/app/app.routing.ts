import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

import { DefaultComponent } from './default.component';

const appRoutes: Routes = [
    {
        path: '',
        component: DefaultComponent
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes, { enableTracing: true });
