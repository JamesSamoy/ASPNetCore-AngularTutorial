import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './layout/app.component';
import { AppRoutingModule } from './app-routing.module';

import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSidenavModule} from '@angular/material/sidenav';
import { HeadComponent } from './layout/head.component';
import { LeftPanelComponent } from './layout/left-panel.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UsersComponent } from './components/users/users.component';
import { Helpers } from './helpers/helpers';
import { AuthGuard } from './helpers/canActivateAuthGuard';
import { TokenService } from './services/token.service';
import { AppConfig } from './config/AppConfig';
import { BaseService } from './services/base.service';
import { TopicsComponent } from './components/topics/topics.component';
import { BlogComponent } from './components/blog/blog.component';
import { FooterComponent } from './layout/footer/footer.component';


@NgModule({
  declarations: [
    AppComponent,
    HeadComponent,
    LeftPanelComponent,
    DashboardComponent,
    UsersComponent,
    TopicsComponent,
    BlogComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatInputModule,
    MatFormFieldModule,
    MatSidenavModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    Helpers,
    AuthGuard,
    TokenService,
    AppConfig,
    BaseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
