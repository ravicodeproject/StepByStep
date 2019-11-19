import { ListsComponent } from './lists/lists.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { Routes } from '@angular/router';

import { MessagesComponent } from './messages/messages.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'messages', component: MessagesComponent },
      { path: 'employees', component: EmployeeListComponent },
      { path: 'lists', component: ListsComponent }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
