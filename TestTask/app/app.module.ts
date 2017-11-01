import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { MultiselectDropdownModule } from 'angular-2-dropdown-multiselect';
import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { HomeComponent } from './components/home.component';
import { ProductService } from './Service/product.service';
import {ProductComponent} from './components/product.component';
import { BasketService } from './Service/basket.service';
import {BasketComponent} from './components/basket.component';

@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, routing, Ng2Bs3ModalModule],
    declarations: [AppComponent, HomeComponent, ProductComponent, BasketComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }, ProductService, BasketService],
    bootstrap: [AppComponent]
})
export class AppModule {
}