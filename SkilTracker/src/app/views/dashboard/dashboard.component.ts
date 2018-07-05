import { Component, OnInit } from '@angular/core';
import { Associate } from '../../models/Associate';
import {NgModule} from '@angular/core';

import {RouterModule, Routes, Router } from '@angular/router';
import { AssociateService } from '../../services/associate.service';
import { AssociateDashboard } from '../../models/associate-dashboard';
import { SkillsService } from '../../services/skills.service';
import { DashboardService } from '../../services/dashboard.service';
import { Skill } from '../../models/Skill';
import { StatisticsDashboard } from '../../models/statistics-dashboard';
import { SearchFilterPipe } from '../../pipes/search-filter.pipe';
import Chart from 'chart.js';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

    message: string;
    searchname: string;
    searchid: string;
    searchemail: string;
    searchmobile: string;
    searchskill: string;
    associateItem: Associate;
    associateList: AssociateDashboard[];
    skillist: Skill[];
    dashboard: StatisticsDashboard[];
    public labels: string[] = [];
    public chartData: number[] = [];
    ChartLegend: boolean = true;
    public lineChartOptions: any = {
        responsive: true
    };
    chartType: string = "bar";

    TotalAssociates: number;
    Level1EmpPerc: number = 0;
    Level2EmpPerc: number = 0;
    Level3EmpPerc: number = 0;
    GreenEmpPerc: number = 0;
    BlueEmpPerc: number = 0;
    RedEmpPerc: number = 0;

    constructor(private router: Router, private _service: DashboardService) {
        this.associateItem = new Associate();

    }

    ngOnInit() {
        this.GetAssociateDetails();
        this._service.GetDashboardStatistics()
            .subscribe(d => { this.dashboard = d; this.SetChart(); })
    }

    SetChart() {
        for (let i = 0; i < this.dashboard.length; i++) {
            this.labels.push(this.dashboard[i].skillname);
            this.chartData.push(this.dashboard[i].skillcount);
        }

    }

    SetStatistics() {
        this.TotalAssociates = this.associateList.length
        let Level1Emp = 0, Level2Emp = 0, Level3Emp = 0;
        let BlueEmp = 0, GreenEmp = 0, RedEmp = 0;
        for (let i = 0; i < this.associateList.length; i++) {
            if (this.associateList[i].level1 == 1)
                Level1Emp++;
            if (this.associateList[i].level2 == 1)
                Level2Emp++;
            if (this.associateList[i].level3 == 1)
                Level3Emp++;

            if (this.associateList[i].statusblue == 1)
                BlueEmp++;
            if (this.associateList[i].statusgreen == 1)
                GreenEmp++;
            if (this.associateList[i].statusred == 1)
                RedEmp++;
        }
        this.Level1EmpPerc = Math.round(Level1Emp / this.TotalAssociates * 100);
        this.Level2EmpPerc = Math.round(Level2Emp / this.TotalAssociates * 100);
        this.Level3EmpPerc = Math.round(Level3Emp / this.TotalAssociates * 100);
        this.BlueEmpPerc = Math.round(BlueEmp / this.TotalAssociates * 100);
        this.GreenEmpPerc = Math.round(GreenEmp / this.TotalAssociates * 100);
        this.RedEmpPerc = Math.round(RedEmp / this.TotalAssociates * 100);

    }

    public chartClicked(e: any): void {
        console.log(e);
    }

    public chartHovered(e: any): void {
        console.log(e);
    }

    GetAssociateDetails() {
        this._service.GetAssociateDetails()
            .subscribe(a => { this.associateList = a; this.SetStatistics() });
    }

    EditClicked(item: Associate) {
        this.router.navigate(['./Associate', item.associateid]);
    }

    DeleteClicked(item: Associate) {
        this._service.DeleteAssociateDetails(item.associateid)
            .subscribe(e => { this.message = e; this.GetAssociateDetails(); })
    }

    ViewClicked(item: Associate) {

    }
    AddAssociateClicked() {
        // this.router.navigate(["./addemployeeskills"])
    }

}
