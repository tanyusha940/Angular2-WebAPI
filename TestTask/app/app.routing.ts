import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home.component';
import {ProductComponent} from './components/product.component';
import {BasketComponent} from './components/basket.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'product', component: ProductComponent},
    { path: 'basket', component: BasketComponent}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);