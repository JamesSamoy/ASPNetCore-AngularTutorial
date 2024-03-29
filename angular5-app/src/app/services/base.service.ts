import { HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { throwError, concat, of } from 'rxjs';
import { Helpers } from "../helpers/helpers";

@Injectable()
export class BaseService {
    constructor(private helper: Helpers){}
    public extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    public handleError(error: Response | any){
        // In a real-world app, we might use a remote logging infastructure
        let errMsg: string;
        if(error instanceof Response) {
            const body = error.json() || '';
            const err = body || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        window.alert(errMsg);
        return throwError(errMsg);
        //return Observable.throw(errMsg);
    }

    public header(){
        let header = new HttpHeaders({ 'Access-Control-Allow-Origin':'*', 'Content-Type': 'application/json' });
        if(this.helper.isAuthenticated()) {
            header = header.append('Authorization', 'Bearer ' + this.helper.getToken());
        }

        return { headers: header };
    }

    public setToken(data:any) {
        this.helper.setToken(data);
    }

    public failToken(error: Response | any) {
        this.helper.failToken();
        return this.handleError(Response);
    }
}