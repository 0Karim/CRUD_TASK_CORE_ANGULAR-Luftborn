import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { AlertService, UserService } from '@app/_services';
import { PageResult, User } from '@app/_models';
import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core/testing';
import { environment } from '@environments/environment';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {

    baseUrl : string = `${environment.apiUrl}/api/User/`;

    public users : User[] | undefined = [];

    public pageNumber: number | undefined = 1;
    public pageSize: number = 10;
    public Counter: number | undefined = 0;


    constructor(private userService: UserService , private alertService : AlertService) {}

    ngOnInit() {
        this.userService.getAllUsersWitPagination(this.pageNumber , this.pageSize)
            .pipe(first())
            .subscribe(result => {
                console.log(result)
                this.users = result.items;
                this.pageNumber = result.pageNumber;
                this.Counter = result.totalCount;
            });
    }

    deleteUser(id: string) 
    {
        if(confirm('Are you sure you want to delete this user ?'))
        {

            this.userService.delete(parseInt(id))
                .pipe(first())
                .subscribe(result =>{
                    console.log(result);                    
                    this.alertService.success('User deleted', { keepAfterRouteChange: true });
                    this.userService.getAllUsersWitPagination(this.pageNumber , this.pageSize)
                    .pipe(first())
                    .subscribe(result => {
                        console.log(result)
                        this.users = result.items;
                        this.pageNumber = result.pageNumber;
                        this.Counter = result.totalCount;
                    });                    
                });
            }
    }

    
}