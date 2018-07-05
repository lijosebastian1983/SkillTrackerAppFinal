using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SkillTrackerDataLayer.Entities;
using SkillTracker.Controllers;
using SkillTrackerDataLayer.Entties;
using System.Web.Http;
using System.Web.Http.Results;

namespace SkillTrackerTest
{
    [TestFixture]
    public class EmployeeSkillTest
    {
        [Test, Order(1)]
        public void AddEmpSkillTest()
        {
            EmployeeSkillController empController = new EmployeeSkillController();
            EmployeeDetails empDetails = new EmployeeDetails();
            empDetails.associateDetails = GenerateAssociateDetails();

             List<SkillDetails> skillDetails= empController.GetEmployeeSkills(0);
            empDetails.associateSkills = (from sd in skillDetails
                                          select new AssociateSkill
                                          {
                                              associateid = sd.associateId,
                                              skillid = sd.skillid,
                                              rating = 5
                                          }).ToList();
          IHttpActionResult response = empController.AddEmpSkill(empDetails);
            var contentResult = response as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.ToString(), "Success");
        }

        [Test, Order(2)]
        public void GetAllAssociateDetailsTest()
        {
            EmployeeSkillController empController = new EmployeeSkillController();
            IList<AssociateDetailsDashboard> response = empController.GetAllAssociateDetails();
            Assert.IsNotNull(response);
        }

        [Test, Order(3)]
        public void GetEmployeeSkillsTest()
        {
            EmployeeSkillController empController = new EmployeeSkillController();
            EmployeeDetails empDetails = new EmployeeDetails();
            empDetails.associateDetails = GetLastAssociateDetails();
            if (empDetails.associateDetails == null)
                empDetails.associateDetails.associateid = 0;
            IList<SkillDetails> response = empController.GetEmployeeSkills(empDetails.associateDetails.associateid);
            Assert.IsNotNull(response);
        }

        [Test, Order(4)]
        public void GetEmployeeDetailsByIdTest()
        {
            EmployeeSkillController empController = new EmployeeSkillController();
            EmployeeDetails empDetails = new EmployeeDetails();
            empDetails.associateDetails = GetLastAssociateDetails();
            EmployeeDetails response = empController.GetEmployeeDetailsById(empDetails.associateDetails.associateid);
            Assert.IsNotNull(response);
        }

        [Test, Order(5)]
        public void GetDashboardStatisticsTest()
        {
            EmployeeSkillController empController = new EmployeeSkillController();
            List<DashboardStatistics> dashBoardDetails = new List<DashboardStatistics>();
            dashBoardDetails = empController.GetDashboardStatistics();
            Assert.IsNotNull(dashBoardDetails);
        }

        [Test, Order(6)]
        public void UpdateEmpSkillTest()
        {
            EmployeeDetails empDetails = new EmployeeDetails();
            empDetails.associateDetails = GetLastAssociateDetails();
            empDetails.associateDetails.associatename = "Updated Name";
            empDetails.associateDetails.remarks = "Updated Remarks";
            empDetails.associateDetails.mobile = "9876543210";
            empDetails.associateSkills = null;
            EmployeeSkillController empController = new EmployeeSkillController();
            IHttpActionResult response = empController.UpdateEmpSkill(empDetails);
            var contentResult = response as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.ToString(), "Success");
        }

        [Test, Order(7)]
        public void DeleteEmpSkillTest()
        {
            EmployeeDetails empDetails = new EmployeeDetails();
            empDetails.associateDetails = GetLastAssociateDetails();
            EmployeeSkillController empController = new EmployeeSkillController();
            IHttpActionResult response = empController.DeleteAssociateDetails(empDetails.associateDetails.associateid);
            var contentResult = response as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.ToString(), "Success");
        }

        public AssociateDetails GetLastAssociateDetails()
        {
            EmployeeSkillController empController = new EmployeeSkillController();
            IList<AssociateDetailsDashboard> response = empController.GetAllAssociateDetails();
            return new AssociateDetails {
            associateid = response[response.Count - 1].associateid,
                associatename = response[response.Count - 1].associatename,
                email = response[response.Count - 1].email,
                mobile = response[response.Count - 1].mobile,
                statusblue = response[response.Count - 1].associateid,
                statusgreen = response[response.Count - 1].associateid,
                statusred = response[response.Count - 1].associateid,
                level1 = response[response.Count - 1].associateid,
                level2 = response[response.Count - 1].associateid,
                level3 = response[response.Count - 1].associateid,
                remarks = response[response.Count - 1].remarks,
                strength = response[response.Count - 1].strength,
                weakness = response[response.Count - 1].weakness,
                image = response[response.Count - 1].image,

            } ;
        }

        public AssociateDetails GenerateAssociateDetails()
        {
            AssociateDetails associateDetail = new AssociateDetails();
            associateDetail.associatename = "UnitTest Name";
            associateDetail.email = "UnitTest@test.com";
            associateDetail.mobile = "1234567890";
            associateDetail.statusblue = 0;
            associateDetail.statusgreen = 1;
            associateDetail.statusred = 0;
            associateDetail.level1 = 1;
            associateDetail.level2 = 0;
            associateDetail.level3 = 0;
            associateDetail.remarks = "Test Remarks";
            associateDetail.strength = "Test strength";
            associateDetail.weakness = "Test Weakness";

            return associateDetail;
        }
        
    }
}
