import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { catchError } from "rxjs/operators";
import { AppConfig } from "../config/AppConfig";
import { Helpers } from "../helpers/helpers";
import { User } from "../models/user";
import { BaseService } from "./base.service";

@Injectable()
export class UserService extends BaseService {
    private pathAPI = this.config.setting['PathAPI'];
    
    constructor(private http: HttpClient, private config: AppConfig, helper: Helpers){
        super(helper);
    }

    // GET Heroes from the server
    getUsers (): Observable<User[]> {
        return this.http.get<User[]>(this.pathAPI + 'user', super.header()).pipe(
            catchError(super.handleError)
        );
    }
}