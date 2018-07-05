import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {map}from 'rxjs/operators';
import {Http, Response, HttpModule} from '@angular/http';
import { Skill } from '../Models/Skill';

@Injectable()
export class SkillsService {

    apiurl: string = "http://localhost:37210/api/";
    constructor(private _http: Http) { }

    GetAllSkills(): Observable<Skill[]> {
        return this._http.get(this.apiurl + "skills/GetAllSkills")
            .pipe(map((response: Response) => <Skill[]>response.json()));
    }

    AddSkill(skillItem: Skill): Observable<String> {
        return this._http.post(this.apiurl + "skills/AddSkill", skillItem)
            .pipe(map((response: Response) => <string>response.json()));
    }

    UpdateSkill(skillItem: Skill): Observable<string> {
        return this._http.put(this.apiurl + "skills/UpdateSkill", skillItem)
            .pipe(map((response: Response) => <string>response.json()));
    }

    DeleteSkill(skillid: number): Observable<string> {
        return this._http.delete(this.apiurl + "skills/DeleteSkill?skillid=" + skillid)
            .pipe(map((response: Response) => <string>response.json()));
    }
}
