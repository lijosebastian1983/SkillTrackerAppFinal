import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {Http, Response, HttpModule} from '@angular/http';
import { StatisticsDashboard } from '../models/statistics-dashboard';
import { AssociateDashboard } from '../models/associate-dashboard';

@Injectable()
export class DashboardService {

    apiurl: string = "http://localhost:37210/api/"

    constructor(private _http: Http) { }

    GetDashboardStatistics(): Observable<StatisticsDashboard[]> {
        return this._http.get(this.apiurl + "employee/GetDashboardStatistics")
            .pipe(map((response: Response) => <StatisticsDashboard[]>response.json()));
    }

    GetAssociateDetails(): Observable<AssociateDashboard[]> {
        return this._http.get(this.apiurl + "employee/GetAssociateDetails")
            .pipe(map((response: Response) => <AssociateDashboard[]>response.json()));
    }

    DeleteAssociateDetails(associateId: number): Observable<string> {
        return this._http.delete(this.apiurl + "employee/DeleteAssociateDetails?associateid=" + associateId)
            .pipe(map((response: Response) => <string>response.json()));
    }
}
