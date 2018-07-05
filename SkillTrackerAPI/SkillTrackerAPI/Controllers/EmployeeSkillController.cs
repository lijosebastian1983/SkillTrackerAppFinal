using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SkillTrackerDataLayer;
using System.Web.Http.Cors;
using SkillTrackerDataLayer.Entities;
using SkillTrackerDataLayer.Entties;

namespace SkillTracker.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeSkillController : ApiController
    {
        SkillTRacker_datalayer dataLayer = new SkillTRacker_datalayer();

        [HttpPost]
        [Route("api/employee/AddEmpSkill")]
        public IHttpActionResult AddEmpSkill(EmployeeDetails empdetails)
        {
            int rowAffected = dataLayer.AddEmpSkill(empdetails.associateDetails, empdetails.associateSkills);

            if (rowAffected > 0)
                return Ok("Success");
            else
                return NotFound();

        }

        [HttpPut]
        [Route("api/employee/UpdateEmpSkill")]
        public IHttpActionResult UpdateEmpSkill(EmployeeDetails empDetails)
        {
            int rowAffected = dataLayer.UpdateEmpSkill(empDetails.associateDetails, empDetails.associateSkills);

            if (rowAffected > 0)
                return Ok("Success");
            else
                return NotFound();

        }

        [HttpGet]
        [Route("api/employee/GetAssociateDetails")]
        public List<AssociateDetailsDashboard> GetAllAssociateDetails()
        {
            return dataLayer.GetAllAssociateDetails();
        }

        [HttpGet]
        [Route("api/employee/GetDashboardStatistics")]
        public List<DashboardStatistics> GetDashboardStatistics()
        {
            return dataLayer.GetDashboardStatistics();
        }

        [HttpGet]
        [Route("api/employee/GetEmployeeSkills")]
        public List<SkillDetails> GetEmployeeSkills(int associateId)
        {
            return dataLayer.GetEmployeeSkills(associateId);
        }

        [HttpGet]
        [Route("api/employee/GetEmployeeDetailsById")]
        public EmployeeDetails GetEmployeeDetailsById(int associateId)
        {
            return dataLayer.GetEmployeeDetailsById(associateId);
        }

        [HttpDelete]
        [Route("api/employee/DeleteAssociateDetails")]
        public IHttpActionResult DeleteAssociateDetails(int associateId)
        {
            int rowAffected = dataLayer.DeleteAssociateDetails(associateId);

            if (rowAffected > 0)
                return Ok("Success");
            else
                return NotFound();
        }


    }
}
