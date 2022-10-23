import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import {HttpClient} from '@angular/common/http';
import {AppConfig} from '../config/AppConfig';
import {Helpers} from '../helpers/helpers';
import {Observable} from 'rxjs';
import {catchError} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TopicDataService extends BaseService{

  private pathAPI = this.config.setting['PathAPI'];
  public errorMessage: string;
  constructor(private http: HttpClient, private config: AppConfig, helper: Helpers) {
    super(helper);
  }

  getTopics(): Observable<any> {
    return this.http.get(this.pathAPI + 'UserPost/GetTopics').pipe(
      catchError(super.handleError)
    );
  }
}
