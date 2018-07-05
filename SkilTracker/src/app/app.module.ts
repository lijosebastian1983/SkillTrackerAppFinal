import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {Http, HttpModule} from '@angular/http';
import {RouterModule, Routes} from '@angular/router';  
import { AppComponent } from './app.component';
import { AddEditSkillsComponent } from './views/add-edit-skills/add-edit-skills.component';
import { AddEditAssociatesComponent } from './views/add-edit-associates/add-edit-associates.component';
import { DashboardComponent } from './Views/dashboard/dashboard.component';
import { AppRoutingModule } from './app-routing-module/app-routing-module';
import { SkillsService } from './services/skills.service';
import { DashboardService } from './services/dashboard.service';
import { AssociateService } from './services/associate.service';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import Chart from 'chart.js';
import { SearchFilterPipe } from './pipes/search-filter.pipe';


@NgModule({
  declarations: [
    AppComponent,
    AddEditSkillsComponent,
    AddEditAssociatesComponent,
    DashboardComponent,
      SearchFilterPipe,
      SearchFilterPipe       
  ],
  imports: [
      BrowserModule,
      FormsModule,
      HttpModule,
      ChartsModule,
    AppRoutingModule
  ],
  providers: [SkillsService, DashboardService, AssociateService],
  bootstrap: [AppComponent]
})
export class AppModule { }
