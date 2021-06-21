import { AfterViewInit } from '@angular/core';
import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { delay, startWith } from 'rxjs/operators';
import { Helpers } from '../helpers/helpers';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  subscription: Subscription;
  authentication: boolean;
  constructor(private helpers: Helpers){}
  ngAfterViewInit(){
    this.subscription = this.helpers.isAuthenticationChanged().pipe(
      startWith(this.helpers.isAuthenticated()),
      delay(0)).subscribe((value: boolean) =>
        this.authentication = value
    );
  }
  title = 'angular5-app';
  ngOnDestroy(){
    this.subscription.unsubscribe();
  }
}
