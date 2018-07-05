using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillTrackerDataLayer.Entities;
using SkillTrackerDataLayer.Entties;

namespace SkillTrackerDataLayer
{
    public class SkillTRacker_datalayer
    {
        public IList<Skillmaster> GetAllSkills()
        {
            using (SkillTrackerContext contextObj = new SkillTrackerContext())
            {
                return contextObj.SkillMaster.ToList();
            }
        }

        public int AddSkill(Skillmaster skill)
        {
            int returnValue=0;

            using (SkillTrackerContext contextObj = new SkillTrackerContext())
            {
                contextObj.SkillMaster.Add(skill);
                returnValue = contextObj.SaveChanges();
            }
            return returnValue;

        }

        public int UpdateSkill(Skillmaster skill)
        {
            int returnValue = 0;
            using(SkillTrackerContext contextObj=new SkillTrackerContext())
            {
                Skillmaster SkillItem = contextObj.SkillMaster.SingleOrDefault(s => s.skillid == skill.skillid);
                SkillItem.skillname = skill.skillname;
                returnValue = contextObj.SaveChanges();
            }
            return returnValue;
        }

        public int DeleteSkill(int SkillId)
        {
            int returnValue = 0;

            using(SkillTrackerContext contextObj = new SkillTrackerContext())
            {
                Skillmaster SkillItem = contextObj.SkillMaster.SingleOrDefault(s => s.skillid == SkillId);
                contextObj.SkillMaster.Remove(SkillItem);
                returnValue = contextObj.SaveChanges();
            }

            return returnValue;
        }

        public  int AddEmpSkill(AssociateDetails empDetails, List<AssociateSkill> empSkills)
        {
            int returnValue = 0;

            using (SkillTrackerContext contextObj = new SkillTrackerContext())
            {
                contextObj.AssociateDetails.Add(empDetails);

                if(empSkills!=null)
                {
                    foreach (AssociateSkill empSkill in empSkills)
                    {
                        contextObj.AssociateSkill.Add(empSkill);
                    }
                }
                returnValue = contextObj.SaveChanges();
            }
            return returnValue;
        }

        public int UpdateEmpSkill(AssociateDetails empDetails, List<AssociateSkill> empSkills)
        {
            int returnValue = 0;

            using (SkillTrackerContext contextObj = new SkillTrackerContext())
            {
                AssociateDetails associateDetails = contextObj.AssociateDetails.SingleOrDefault(e => e.associateid == empDetails.associateid);
                associateDetails.associatename = empDetails.associatename;
                associateDetails.email = empDetails.email;
                associateDetails.mobile = empDetails.mobile;
                associateDetails.image = empDetails.image;
                associateDetails.statusgreen = empDetails.statusgreen;
                associateDetails.statusblue = empDetails.statusblue;
                associateDetails.statusred = empDetails.statusred;
                associateDetails.level1 = empDetails.level1;
                associateDetails.level2 = empDetails.level2;
                associateDetails.level3 = empDetails.level3;
                associateDetails.remarks = empDetails.remarks;
                associateDetails.strength = empDetails.strength;
                associateDetails.weakness = empDetails.weakness;

                if (empSkills != null)
                {
                    foreach (AssociateSkill empSkill in empSkills)
                    {
                        AssociateSkill associateSkill = contextObj.AssociateSkill.SingleOrDefault(e=>e.associateid == empSkill.associateid && e.skillid==empSkill.skillid);

                        if (associateSkill != null)
                            associateSkill.rating = empSkill.rating;
                        else
                            contextObj.AssociateSkill.Add(empSkill);
                    }
                }
                returnValue = contextObj.SaveChanges();
            }

            return returnValue;
        }

        public List<AssociateDetailsDashboard> GetAllAssociateDetails()
        {
            using (SkillTrackerContext contextObj = new SkillTrackerContext())
            {
                IList<AssociateDetails> associateDetails =  contextObj.AssociateDetails.ToList();
                List<AssociateSkill> associateSkill = contextObj.AssociateSkill.ToList();
                List<Skillmaster> skillmaster = contextObj.SkillMaster.ToList();

                List<AssociateDetailsDashboard> associateDetailsDashboard
                        = (from ad in associateDetails
                           join asl in associateSkill.Where(a=>a.rating>0)
                           on ad.associateid equals asl.associateid
                           join sm in skillmaster
                           on asl.skillid equals sm.skillid
                           group new { ad, sm } by new
                           {
                               ad.associateid,
                               ad.associatename,
                               ad.email,
                               ad.mobile,
                               ad.image,
                               ad.statusgreen,
                               ad.statusblue,
                               ad.statusred,
                               ad.level1,
                               ad.level2,
                               ad.level3,
                               ad.remarks,
                               ad.strength,
                               ad.weakness
                           } into dashboard
                           select new AssociateDetailsDashboard
                           {
                               associateid = dashboard.Key.associateid,
                               associatename = dashboard.Key.associatename,
                               email = dashboard.Key.email,
                               mobile = dashboard.Key.mobile,
                               image = dashboard.Key.image,
                               statusgreen = dashboard.Key.statusgreen,
                               statusblue = dashboard.Key.statusblue,
                               statusred = dashboard.Key.statusred,
                               level1 = dashboard.Key.level1,
                               level2 = dashboard.Key.level2,
                               level3 = dashboard.Key.level3,
                               remarks = dashboard.Key.remarks,
                               strength = dashboard.Key.strength,
                               weakness = dashboard.Key.weakness,
                               skillset = string.Join(",", dashboard.Select(s => s.sm.skillname))
                           }).ToList();

                return associateDetailsDashboard;

            }
        }


        public List<SkillDetails> GetEmployeeSkills(int associateId)
        {
            using (SkillTrackerContext contextObj=new SkillTrackerContext())
            {
                List<Skillmaster> skillMaster = contextObj.SkillMaster.ToList();
                List<AssociateSkill> associateSkill = contextObj.AssociateSkill.ToList();
                List<SkillDetails> skillDetails = (from sm in skillMaster
                                                   join es in associateSkill.Where(a => a.associateid == associateId)
                                                   on sm.skillid equals es.skillid
                                                   into sd
                                                   from eskill in sd.DefaultIfEmpty(new AssociateSkill())
                                                   select new SkillDetails
                                                   {
                                                       Skillname = sm.skillname,
                                                       skillid = sm.skillid,
                                                       associateId = associateId,
                                                       rating = eskill.rating
                                                   }).ToList();

                return skillDetails;

            }
        }

        public EmployeeDetails GetEmployeeDetailsById(int associateId)
        {
            EmployeeDetails empDetails = new EmployeeDetails();

            using(SkillTrackerContext contextObj =new SkillTrackerContext())
            {
                empDetails.associateDetails = contextObj.AssociateDetails.SingleOrDefault(a => a.associateid == associateId);
                empDetails.associateSkills = contextObj.AssociateSkill.Where(s => s.associateid == associateId).ToList();
            }

            return empDetails;
            
        }

        public int DeleteAssociateDetails(int associateId)
        {
            int returnValue = 0;

            using (SkillTrackerContext contextObj = new SkillTrackerContext())
            {
                AssociateDetails associateDetails = contextObj.AssociateDetails.SingleOrDefault(s => s.associateid == associateId);
                contextObj.AssociateDetails.Remove(associateDetails);
                List<AssociateSkill> associateSkill = contextObj.AssociateSkill.Where(s =>  s.associateid == associateId).ToList();
                if (associateSkill != null)
                {
                    contextObj.AssociateSkill.RemoveRange(associateSkill);
                }
 
                returnValue = contextObj.SaveChanges();
            }

            return returnValue;
        }

        public List<DashboardStatistics> GetDashboardStatistics()
        {
            using (SkillTrackerContext contextObj = new SkillTrackerContext())
            {
                List<AssociateSkill> associateSkill = contextObj.AssociateSkill.ToList();
                List<Skillmaster> skillmaster = contextObj.SkillMaster.ToList();
                List<DashboardStatistics> dashboard = (from ask in associateSkill.Where(a => a.rating > 0)
                                                       join sm in skillmaster
                                                       on ask.skillid equals sm.skillid
                                                       group sm by sm.skillname into db
                                                       select new DashboardStatistics
                                                       {
                                                           skillname = db.Key,
                                                           skillcount = db.Count()
                                                       }).ToList();

                return dashboard;

            }

        }

    }
}
