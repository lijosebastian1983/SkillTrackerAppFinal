using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDataLayer.Entities
{
    public class AssociateSkill
    {
        [Key, Column(Order = 0)]
        [ForeignKey("associateDetails")]
        public int associateid { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("skillMaster")]
        public int skillid { get; set; }

        public int rating { get; set; }

        public AssociateDetails associateDetails { get; set; }
        public Skillmaster skillMaster { get; set; }
    }
}
