using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDataLayer.Entities
{
    public class Skillmaster
    {
        [Key]
        public int skillid { get; set; }
        public string skillname { get; set; }
    }
}
