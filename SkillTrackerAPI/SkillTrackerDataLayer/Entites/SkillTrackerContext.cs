using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDataLayer.Entities
{
    public class SkillTrackerContext : DbContext
    {
        static SkillTrackerContext()
        {
            Database.SetInitializer<SkillTrackerContext>(new CreateDatabaseIfNotExists<SkillTrackerContext>());
        }

        public SkillTrackerContext() : base("name=skilltrackerconnection") { }

        public DbSet<AssociateDetails> AssociateDetails { get; set; }
        public DbSet<AssociateSkill> AssociateSkill { get; set; }
        public DbSet<Skillmaster> SkillMaster { get; set; }

    }
}
