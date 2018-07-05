import { Component, OnInit } from '@angular/core';
import {RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import { Associate } from '../../models/Associate';
import { Skill } from '../../models/Skill';
import { AssociateService } from '../../services/associate.service';
import { AssociateSkill } from '../../models/associate-skill';
import { AssociateDetails } from '../../models/associate-details';

@Component({
  selector: 'app-add-edit-associates',
  templateUrl: './add-edit-associates.component.html',
  styleUrls: ['./add-edit-associates.component.css']
})
export class AddEditAssociatesComponent implements OnInit {

    greenButtonStyle: string;
    blueButtonStyle: string;
    redButtonStyle: string;

    level1style: string;
    level2style: string;
    level3style: string;
    addFlag: boolean;
    title: string;

    message: String;
    SkillList: AssociateSkill[];
    skill: AssociateSkill;
    employeeSkills: AssociateSkill[];
    associateId: number;

    associateItem: Associate = new Associate();
    empDetails: AssociateDetails = new AssociateDetails();
    SelectedImage: any;
    private imageChanged: boolean = false;

    constructor(private router: Router, private _service: AssociateService, private route: ActivatedRoute) {
        this.associateId = this.route.snapshot.params.associateId;
        if (this.associateId == 0) {
            this.title = "Skill Tracker : Add New Employee Skills";
            this.addFlag = true;
            this.SelectStatus(1, 0, 0);
            this.SelectLevel(1, 0, 0);
            this.GetEmployeeSkills();
        }
        else {
            this.title = "Skill Tracker : Update Employee Skills";
            this.addFlag = false;
            this.GetAssociateDetailsById();
        }

    }

    ngOnInit() {
        this.associateItem.associateid = 0;

    }

    SetValues() {
        this.SelectStatus(this.associateItem.statusgreen, this.associateItem.statusblue, this.associateItem.statusred);
        this.SelectLevel(this.associateItem.level1, this.associateItem.level2, this.associateItem.level3);
    }

    GetAssociateDetailsById() {
        this._service.GetAssociateDetailsById(this.associateId)
            .subscribe(e => { this.empDetails = e; this.associateItem = this.empDetails.associateDetails; this.GetEmployeeSkills(); this.SetValues(); });
    }

    AddEmpSkill() {
        this.SkillList = new Array<AssociateSkill>();
        for (var i = 0; i < this.employeeSkills.length; i++) {
            this.skill = new AssociateSkill;
            this.skill.associateId = this.employeeSkills[i].associateId;
            this.skill.rating = this.employeeSkills[i].rating;
            this.skill.skillid = this.employeeSkills[i].skillid;
            this.SkillList.push(this.skill);
        }

        this.empDetails.associateDetails = this.associateItem;
        this.empDetails.associateSkills = this.SkillList;
        this._service.PostEmpSkill(this.empDetails)
            .subscribe(e => { this.message = e; this.router.navigate(['/Dashboard']) });

    }

    UpdateEmpSkill() {
        this.SkillList = new Array<AssociateSkill>();
        for (var i = 0; i < this.employeeSkills.length; i++) {
            this.skill = new AssociateSkill;
            this.skill.associateId = this.employeeSkills[i].associateId;
            this.skill.rating = this.employeeSkills[i].rating;
            this.skill.skillid = this.employeeSkills[i].skillid;
            this.SkillList.push(this.skill);
        }

        this.empDetails.associateDetails = this.associateItem;
        this.empDetails.associateSkills = this.SkillList;
        this._service.PutEmpSkill(this.empDetails)
            .subscribe(e => { this.message = e; this.router.navigate(['/Dashboard']) });

    }

    GetEmployeeSkills() {
        this._service.GetEmployeeSkills(this.associateId)
            .subscribe(es => this.employeeSkills = es);
    }

    SelectStatus(green: number, blue: number, red: number) {
        this.associateItem.statusgreen = green;
        this.associateItem.statusblue = blue;
        this.associateItem.statusred = red;
        if (green) {
            this.greenButtonStyle = "5pt";
            this.blueButtonStyle = "0pt";
            this.redButtonStyle = "0pt";
        }
        else if (blue) {
            this.greenButtonStyle = "0pt";
            this.blueButtonStyle = "5pt";
            this.redButtonStyle = "0pt";
        }
        else {
            this.greenButtonStyle = "0pt";
            this.blueButtonStyle = "0pt";
            this.redButtonStyle = "5pt";
        }
    }

    SelectLevel(level1: number, level2: number, level3: number) {
        this.associateItem.level1 = level1;
        this.associateItem.level2 = level2;
        this.associateItem.level3 = level3;

        if (level1) {
            this.level1style = "5pt";
            this.level2style = "0pt";
            this.level3style = "0pt";
        }
        else if (level2) {
            this.level1style = "0pt";
            this.level2style = "5pt";
            this.level3style = "0pt";
        }
        else {
            this.level1style = "0pt";
            this.level2style = "0pt";
            this.level3style = "5pt";
        }
    }

    ChangeRating(item: AssociateSkill, rating: number) {
        item.rating = rating;
        let indexval = this.employeeSkills.indexOf(item);
        this.employeeSkills[indexval].rating = rating;
    }

    ChangeImage(event) {
        let reader = new FileReader();
        if (event.target.files && event.target.files[0]) {
            this.imageChanged = true;
            let file = event.target.files[0];
            reader.onload = () => {
                this.SelectedImage = reader.result;
            };
            reader.readAsDataURL(file);
        }
    }

}
