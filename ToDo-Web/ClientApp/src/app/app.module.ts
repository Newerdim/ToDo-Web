import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { TaskListComponent } from './task-list/task-list.component';
import { TaskComponent } from './task-list/task/task.component';
import { SettingsComponent } from './settings/settings.component';
import { AccountComponent } from './account/account.component';
import { AddTaskComponent } from './task-list/add-task/add-task.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    HeaderComponent,
    TaskListComponent,
    TaskComponent,
    SettingsComponent,
    AccountComponent,
    AddTaskComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
