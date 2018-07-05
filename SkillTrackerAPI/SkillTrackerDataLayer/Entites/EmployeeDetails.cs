using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillTrackerDataLayer.Entities;

namespace SkillTrackerDataLayer.Entties
{
    public class EmployeeDetails
    {
        public AssociateDetails associateDetails { get; set; }
        public List<AssociateSkill> associateSkills { get; set; }
    }
}
