"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var basket_service_1 = require("../Service/basket.service");
var forms_1 = require("@angular/forms");
var ng2_bs3_modal_1 = require("ng2-bs3-modal/ng2-bs3-modal");
var enum_1 = require("../shared/enum");
var global_1 = require("../Shared/global");
var BasketComponent = (function () {
    function BasketComponent(fb, _basketService) {
        this.fb = fb;
        this._basketService = _basketService;
        this.indLoading = false;
    }
    BasketComponent.prototype.ngOnInit = function () {
        this.basketFrm = this.fb.group({
            Id: [''],
            Name: ['', forms_1.Validators.required],
            Products: [''],
        });
        this.Loadbaskets();
    };
    BasketComponent.prototype.Loadbaskets = function () {
        var _this = this;
        this.indLoading = true;
        this._basketService.get(global_1.Global.BASE_BASKET_ENDPOINT)
            .subscribe(function (baskets) { _this.baskets = baskets; _this.indLoading = false; }, function (error) { return _this.msg = error; });
    };
    BasketComponent.prototype.SetControlsState = function (isEnable) {
        isEnable ? this.basketFrm.enable() : this.basketFrm.disable();
    };
    BasketComponent.prototype.addBasket = function () {
        this.dbops = enum_1.DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New basket";
        this.modalBtnTitle = "Add";
        this.basketFrm.reset();
        this.modal.open();
    };
    BasketComponent.prototype.editBasket = function (id) {
        this.dbops = enum_1.DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit basket";
        this.modalBtnTitle = "Update";
        this.basket = this.baskets.filter(function (x) { return x.Id == id; })[0];
        this.basketFrm.setValue(this.basket);
        this.modal.open();
    };
    BasketComponent.prototype.deleteBasket = function (id) {
        this.dbops = enum_1.DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.basket = this.baskets.filter(function (x) { return x.Id == id; })[0];
        this.basketFrm.setValue(this.basket);
        this.modal.open();
    };
    BasketComponent.prototype.onSubmit = function (formData) {
        var _this = this;
        this.msg = "";
        switch (this.dbops) {
            case enum_1.DBOperation.create:
                this._basketService.post(global_1.Global.BASE_BASKET_ENDPOINT, formData._value).subscribe(function (data) {
                    if (data == 1) {
                        _this.msg = "Data successfully added.";
                        _this.Loadbaskets();
                    }
                    else {
                        _this.msg = "There is some issue in saving records, please contact to system administrator!";
                    }
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.update:
                this._basketService.put(global_1.Global.BASE_BASKET_ENDPOINT, formData._value.Id, formData._value).subscribe(function (data) {
                    if (data == 1) {
                        _this.msg = "Data successfully updated.";
                        _this.Loadbaskets();
                    }
                    else {
                        _this.msg = "There is some issue in saving records, please contact to system administrator!";
                    }
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.delete:
                this._basketService.delete(global_1.Global.BASE_BASKET_ENDPOINT, formData._value.Id).subscribe(function (data) {
                    if (data == 1) {
                        _this.msg = "Data successfully deleted.";
                        _this.Loadbaskets();
                    }
                    else {
                        _this.msg = "There is some issue in saving records, please contact to system administrator!";
                    }
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
        }
    };
    return BasketComponent;
}());
__decorate([
    core_1.ViewChild('modal'),
    __metadata("design:type", ng2_bs3_modal_1.ModalComponent)
], BasketComponent.prototype, "modal", void 0);
BasketComponent = __decorate([
    core_1.Component({
        templateUrl: 'app/Components/basket.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, basket_service_1.BasketService])
], BasketComponent);
exports.BasketComponent = BasketComponent;
//# sourceMappingURL=basket.component.js.map