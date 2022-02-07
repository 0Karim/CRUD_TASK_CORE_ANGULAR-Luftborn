import { Role } from './role';

export class User {
    id!: string;
    UserId! : number;
    title!: string;
    firstName!: string;
    middleName!: string;
    lastName!: string;
    birthDate! : Date;
    email!: string;
    mobileNumber! : string
    cityId! : number ;
    govId! : number; 
    buildingNumber! : string;
    street! : string;
    isDeleting: boolean = false;

    public constructor(init?: Partial<User>) {
        Object.assign(this, init);
    }
}

export class PageResult<T>
{
    count : number | undefined;
    pageNumber : number | undefined;
    totalPages : number | undefined;
    totalCount : number | undefined
    hasPreviousPage : boolean | undefined;
    hasNextPage : boolean | undefined
    items: T[] | undefined;
}