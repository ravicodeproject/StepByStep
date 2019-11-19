import { appRoutes } from './routes';
import { Routes, Router, RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule, CollapseModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { ValuesComponent } from './values/values.component';
import { EmployeesComponent } from './employees/employees.component';
import { RegisterComponent } from './register/register.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';


@NgModule({
   declarations: [
      AppComponent,
      ValuesComponent,
      EmployeesComponent,
      RegisterComponent,
      NavComponent,
      HomeComponent,
      ListsComponent,
      MessagesComponent,
      EmployeeListComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(appRoutes),
      BsDropdownModule.forRoot(),
      CollapseModule.forRoot()
   ],
   providers: [
      ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
