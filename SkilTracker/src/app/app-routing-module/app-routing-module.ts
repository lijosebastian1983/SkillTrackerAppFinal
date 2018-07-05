import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AddEditSkillsComponent } from '../views/add-edit-skills/add-edit-skills.component';
import { AddEditAssociatesComponent } from '../views/add-edit-associates/add-edit-associates.component';
import { DashboardComponent } from '../Views/dashboard/dashboard.component';

const routes: Routes = [
    {
      path: '',
      component: DashboardComponent,
  },
    {
      path: 'Dashboard',
      component: DashboardComponent,
  },
  {
      path: 'Associate/:associateId',
    component: AddEditAssociatesComponent,
  },
  {
    path: 'Skills',
    component: AddEditSkillsComponent,
  },
  ];
  
  @NgModule({
    imports: [
      RouterModule.forRoot(routes)
    ],
    exports: [
      RouterModule
  ],
    declarations: []
  })
  export class AppRoutingModule { }
  