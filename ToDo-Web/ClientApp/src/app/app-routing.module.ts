import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TaskListComponent } from './task-list/task-list.component';
import { SettingsComponent } from './settings/settings.component';
import { AccountComponent } from './account/account.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'account', component: AccountComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'tasks', redirectTo: 'tasks/inbox' },
  { path: 'tasks/:name', component: TaskListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
