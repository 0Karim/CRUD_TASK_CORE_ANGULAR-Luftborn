import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { PageResult, User } from '@app/_models';
import { Observable } from 'rxjs';

const baseUrl = `${environment.apiUrl}/api/User/`;

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAllUsersWitPagination(pageNumber : number | undefined , pageSize : number | undefined)
    {
        return this.http
        .get<PageResult<User>>(baseUrl + "GetAllUsers?PageNumber=" + pageNumber + "&PageSize=" + pageSize);
    }

    getById(id: number) {
        return this.http.get<User>(baseUrl + "GetUserById?UserId=" + id);
    }

    create(params: any) 
    {
        console.log(params);
        return this.http.post(baseUrl + "CreateUser" , params);
    }

    update(id: number, params: any) {
        return this.http.put(baseUrl + "UpdateUser?Id=" + id, params);
    }

    delete(id: number) {
        return this.http.delete(baseUrl + "DeleteUser?Id=" + id);
    }
}