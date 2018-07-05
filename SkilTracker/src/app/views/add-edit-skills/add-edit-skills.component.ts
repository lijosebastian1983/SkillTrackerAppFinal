import { Component, OnInit } from '@angular/core';
import {NgModule} from '@angular/core';
import { Skill } from '../../Models/Skill';
import { SkillsService } from '../../services/skills.service';

@Component({
  selector: 'app-add-edit-skills',
  templateUrl: './add-edit-skills.component.html',
  styleUrls: ['./add-edit-skills.component.css']
})
export class AddEditSkillsComponent implements OnInit {   
    skillItem: Skill;
    SkillList: Skill[];
    message: String;
    editFlag: boolean;
    constructor(private _service: SkillsService) {
        this.skillItem = new Skill();

    }

    ngOnInit() {
        this.editFlag = false;
        this.GetAllSkills();
    }

    GetAllSkills() {
        this._service.GetAllSkills()
            .subscribe(s => this.SkillList = s);               
    }

    AddSkill() {
        this.skillItem.skillid = 0;
        this.message = "";
        this._service.AddSkill(this.skillItem)
            .subscribe(s => { this.message = s; this.GetAllSkills(); this.skillItem.skillname = '' });
    };

    UpdateSkill() {
        this.message = "";
        this._service.UpdateSkill(this.skillItem)
            .subscribe(s => { this.message = s; this.GetAllSkills(); });
        this.editFlag = false;
    }

    DeleteSkill(item: Skill) {
        this.message = "";
        this._service.DeleteSkill(item.skillid)
            .subscribe(s => { this.message = s; this.GetAllSkills(); });
    }

    EditClicked(item: Skill) {
        this.message = "";
        this.editFlag = true;
        this.skillItem = item;
    }

    CancelClicked() {
        this.message = "";
        this.editFlag = false;
        this.skillItem = new Skill();
    }


}
