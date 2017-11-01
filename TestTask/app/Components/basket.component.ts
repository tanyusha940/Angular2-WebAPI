import { Component, OnInit, ViewChild } from '@angular/core';
import { BasketService } from '../Service/basket.service';
import { ProductService } from '../Service/product.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { IBasket } from '../Models/basket';
import { IProduct } from '../Models/product';
import { DBOperation } from '../shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../Shared/global';

@Component({

    templateUrl: 'app/Components/basket.component.html'

})

export class BasketComponent implements OnInit {

    @ViewChild('modal') modal: ModalComponent;
    baskets: IBasket[];
    products: IProduct[];
    basket: IBasket;
    msg: string;
    indLoading: boolean = false;
    basketFrm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;

    constructor(private fb: FormBuilder, private _basketService: BasketService, private _productService: ProductService) { }

    ngOnInit(): void {
        this.basketFrm = this.fb.group({
            Id: [''],
            Name: ['', Validators.required],
            Products: [''],
        });

        this.Loadbaskets();
        this.LoadProducts();
    }

    Loadbaskets(): void {
        this.indLoading = true;
        this._basketService.get(Global.BASE_BASKET_ENDPOINT)
            .subscribe(baskets => { this.baskets = baskets; this.indLoading = false; },
                error => this.msg = <any>error);

    }

    LoadProducts(): void {
        this.indLoading = true;
        this._productService.get(Global.BASE_PRODUCT_ENDPOINT)
            .subscribe(products => { this.products = products; this.indLoading = false; },
                error => this.msg = <any>error);

    }

    SetControlsState(isEnable: boolean) {
        isEnable ? this.basketFrm.enable() : this.basketFrm.disable();
    }
    addBasket() {
        this.dbops = DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New basket";
        this.modalBtnTitle = "Add";
        this.basketFrm.reset();
        this.modal.open();
    }

    editBasket(id: number) {
        this.dbops = DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit basket";
        this.modalBtnTitle = "Update";
        this.basket = this.baskets.filter(x => x.Id == id)[0];
        this.basketFrm.setValue(this.basket);
        this.modal.open();
    }

    deleteBasket(id: number) {
        this.dbops = DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.basket = this.baskets.filter(x => x.Id == id)[0];
        this.basketFrm.setValue(this.basket);
        this.modal.open();
    }
    onSubmit(formData: any) {
        this.msg = "";

        switch (this.dbops) {
        case DBOperation.create:
            this._basketService.post(Global.BASE_BASKET_ENDPOINT, formData._value).subscribe(
                data => {
                    if (data >= 1) //Success
                    {
                        this.msg = "Data successfully added.";
                        this.Loadbaskets();
                    }
                    else {
                        this.msg = "There is some issue in saving records, please contact to system administrator!";
                    }

                    this.modal.dismiss();
                },
                error => {
                    this.msg = error;
                }
            );
            break;
        case DBOperation.update:
            this._basketService.put(Global.BASE_BASKET_ENDPOINT, formData._value.Id, formData._value).subscribe(
                data => {
                    if (data >= 1) //Success
                    {
                        this.msg = "Data successfully updated.";
                        this.Loadbaskets();
                    }
                    else {
                        this.msg = "There is some issue in saving records, please contact to system administrator!";
                    }

                    this.modal.dismiss();
                },
                error => {
                    this.msg = error;
                }
            );
            break;
        case DBOperation.delete:
            this._basketService.delete(Global.BASE_BASKET_ENDPOINT, formData._value.Id).subscribe(
                data => {
                    if (data >= 1) //Success
                    {
                        this.msg = "Data successfully deleted.";
                        this.Loadbaskets();
                    }
                    else {
                        this.msg = "There is some issue in saving records, please contact to system administrator!";
                    }

                    this.modal.dismiss();
                },
                error => {
                    this.msg = error;
                }
            );
            break;

        }
    }

}

