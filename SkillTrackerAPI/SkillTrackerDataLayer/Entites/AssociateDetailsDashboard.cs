using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDataLayer.Entities
{
    public class AssociateDetailsDashboard
    {
        public int associateid { get; set; }
        public string associatename { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string image { get; set; }
        public int statusgreen { get; set; }
        public int statusblue { get; set; }
        public int statusred { get; set; }
        public int level1 { get; set; }
        public int level2 { get; set; }
        public int level3 { get; set; }
        public string remarks { get; set; }
        public string strength { get; set; }
        public string weakness { get; set; }
        public string skillset { get; set; }

    }
}
