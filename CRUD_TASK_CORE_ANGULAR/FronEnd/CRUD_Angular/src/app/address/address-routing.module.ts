import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddEditAddressComponent } from './add-edit-address.component';
import { AddressLayoutComponent } from './address-layout.compoent';
import { AddressListComponent } from './list-address.component';


const routes: Routes = [
    {
        path: '', component: AddressLayoutComponent,
        children: [
            { path: '', component: AddressListComponent },
            { path: 'add', component: AddEditAddressComponent },
            { path: 'edit/:id', component: AddEditAddressComponent }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AddressRoutingModule { }