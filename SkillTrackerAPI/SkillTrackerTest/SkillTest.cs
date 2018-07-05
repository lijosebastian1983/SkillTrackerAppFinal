using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SkillTrackerDataLayer.Entities;
using SkillTracker.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;

namespace SkillTrackerTest
{

    [TestFixture]
    public class SkillTest
    {
        [Test, Order(1)]
        public void AddSkillTest()
        {
            Skillmaster skill = new Skillmaster { skillname = "UnitTest Skill" };
            SkillsController skillcontroller = new SkillsController();
            IHttpActionResult response = skillcontroller.AddSkill(skill);
            var contentResult = response as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.ToString(), "Success");
        }

        [Test, Order(2)]
        public void GetAllSkillsTest()
        {
            SkillsController skillcontroller = new SkillsController();
            IList<Skillmaster> skills = skillcontroller.GetAllSkills();
            Assert.IsNotNull(skills);
        }

        [Test, Order(3)]
        public void UpdateSkillTest()
        {
            SkillsController skillcontroller = new SkillsController();
            Skillmaster skill = GetLastSkill();
            skill.skillname = "Test Skill Updated";
            IHttpActionResult response = skillcontroller.UpdateSkill(skill);
            var contentResult = response as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.ToString(), "Success");
        }

        [Test, Order(4)]
        public void DeleteSkillTest()
        {
            SkillsController skillcontroller = new SkillsController();
            Skillmaster skill = GetLastSkill();
            IHttpActionResult response = skillcontroller.DeleteSkill(skill.skillid);
            var contentResult = response as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.ToString(), "Success");
        }

        public Skillmaster GetLastSkill()
        {
            SkillsController skillController = new SkillsController();
            IList<Skillmaster> skills = skillController.GetAllSkills();
            return skills != null ? skills[skills.Count - 1] : null;
        }

    }
}
