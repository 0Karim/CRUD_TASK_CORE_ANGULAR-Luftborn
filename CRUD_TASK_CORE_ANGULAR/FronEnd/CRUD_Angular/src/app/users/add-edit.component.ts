import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { UserService, AlertService } from '@app/_services';
import { User } from '@app/_models';

@Component({ templateUrl: 'add-edit.component.html' })
export class AddEditComponent implements OnInit {
    form!: FormGroup;
    id!: number;
    isAddMode!: boolean;
    loading = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private userService: UserService,
        private alertService: AlertService
    ) {}

    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        this.isAddMode = !this.id;
        
        this.form = this.formBuilder.group({
            FirstName: ['', Validators.required],
            MiddleName : ['' , Validators.required],
            LastName: ['', Validators.required],
            BirthDate :['' , Validators.required],
            MobileNumber : ['' , Validators.required ,],
            Email: ['', Validators.required],
            BuildingNumber : ['' , Validators.required],
            Street : ['' , Validators.required],
            GovId : [],
            CityId : []
        }); 

        if (!this.isAddMode) {
            this.userService.getById(this.id)
                .pipe(first())
                .subscribe(result => 
                    {
                        console.log(result);
                        this.form.patchValue(
                            {                                
                                FirstName: result.firstName,
                                MiddleName: result.middleName,
                                LastName: result.lastName,
                                BirthDate: result.birthDate,
                                MobileNumber: result.mobileNumber,
                                Email: result.email,
                                BuildingNumber: result.buildingNumber,
                                Street: result.street,
                                GovId: result.govId,
                                CityId: result.cityId,
                            });
                    });
        }
    }

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) 
        {
            return;
        }

        this.loading = true;
        if (this.isAddMode) {
            this.createUser();
        } else {
            this.updateUser();
        }
    }

    private createUser() {
        console.log(this.form.value);

        this.userService.create(this.MapFormValuesToUserObj())
            .pipe(first())
            .subscribe(result => {
                console.log(result);
                this.alertService.success('User added', { keepAfterRouteChange: true });
                this.router.navigate(['../'], { relativeTo: this.route });
            })
            .add(() => this.loading = false);
    }

    private updateUser() {
        this.userService.update(this.id, this.MapFormValuesToUserObj())
            .pipe(first())
            .subscribe(() => {
                this.alertService.success('User updated', { keepAfterRouteChange: true });
                this.router.navigate(['../../'], { relativeTo: this.route });
            })
            .add(() => this.loading = false);
    }

    private MapFormValuesToUserObj() : User{
        return new User(this.form.value);
    }
}