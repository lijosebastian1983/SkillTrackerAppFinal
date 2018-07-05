using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDataLayer.Entties
{
    public class SkillDetails
    {
        public string Skillname { get; set; }
        public int skillid { get; set; }
        public int associateId { get; set; }
        public int rating { get; set; }
}
}
