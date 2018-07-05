import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {Http, Response, HttpModule} from '@angular/http';
import { Associate } from '../models/associate';
import { AssociateDetails } from '../models/associate-details';
import { AssociateSkill } from '../models/associate-skill';

@Injectable()
export class AssociateService {

    apiurl: string = "http://localhost:37210/api/"

    constructor(private _http: Http) { }

    PostEmpSkill(empDetails: AssociateDetails): Observable<String> {
        return this._http.post(this.apiurl + "employee/AddEmpSkill", empDetails)
            .pipe(map((response: Response) => <String>response.json()));
    }

    PutEmpSkill(empDetails: AssociateDetails): Observable<string> {
        return this._http.put(this.apiurl + "employee/UpdateEmpSkill", empDetails)
            .pipe(map((response: Response) => <string>response.json()));
    }

    DeleteAssociateDetails(associateId: number): Observable<string> {
        return this._http.delete(this.apiurl + "employee/DeleteAssociateDetails?associateid=" + associateId)
            .pipe(map((response: Response) => <string>response.json()));
    }

    GetEmployeeSkills(associateId: number): Observable<AssociateSkill[]> {
        return this._http.get(this.apiurl + "employee/GetEmployeeSkills?associateid=" + associateId)
            .pipe(map((response: Response) => <AssociateSkill[]>response.json()));
    }

    GetAssociateDetailsById(associateId: number): Observable<AssociateDetails> {
        return this._http.get(this.apiurl + "employee/GetEmployeeDetailsById?associateid=" + associateId)
            .pipe(map((response: Response) => <AssociateDetails>response.json()));
    }
}
