using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SkillTrackerDataLayer;
using SkillTrackerDataLayer.Entities;
using System.Web.Http.Cors;

namespace SkillTracker.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SkillsController : ApiController
    {
        SkillTRacker_datalayer dataLayer = new SkillTRacker_datalayer();

       [HttpGet]
       [Route("api/skills/GetAllSkills")]
        public IList<Skillmaster> GetAllSkills()
        {
            return dataLayer.GetAllSkills();
        }

        [HttpPost]
        [Route("api/skills/AddSkill")]
        public IHttpActionResult AddSkill(Skillmaster skill)
        {
            int rowAffected = dataLayer.AddSkill(skill);

            if(rowAffected>0)
                return Ok("Success");
            else
                return NotFound();
        }

        [HttpPut]
        [Route("api/skills/UpdateSkill")]
        public IHttpActionResult UpdateSkill(Skillmaster skill)
        {
            int rowAffected = dataLayer.UpdateSkill(skill);

            if (rowAffected > 0)
                return Ok("Success");
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("api/skills/DeleteSkill")]
        public IHttpActionResult DeleteSkill(int skillId)
        {
            int rowAffected = dataLayer.DeleteSkill(skillId);

            if (rowAffected > 0)
                return Ok("Success");
            else
                return NotFound();
        }

    }
}
