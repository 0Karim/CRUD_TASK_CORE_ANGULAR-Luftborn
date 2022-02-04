import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AddressRoutingModule } from './address-routing.module';
import { AddressListComponent } from './list-address.component';
import { AddEditAddressComponent } from './add-edit-address.component';
import { AddressLayoutComponent } from './address-layout.compoent';


@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AddressRoutingModule
    ],
    declarations: [
        AddressLayoutComponent,
        AddressListComponent,
        AddEditAddressComponent
    ]
})
export class AddressModule { }