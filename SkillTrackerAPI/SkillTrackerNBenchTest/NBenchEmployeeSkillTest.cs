using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using NBench.Util;
using SkillTrackerTest;

namespace SkillTrackerNBenchTest
{
    class NBenchEmployeeSkillTest
    {
        [PerfBenchmark(NumberOfIterations =1,RunMode =RunMode.Throughput, TestMode =TestMode.Test,
            SkipWarmups =true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds =10000)]
        public void BenchMarkPerformanceEmployeeSkill()
        {
            EmployeeSkillTest empSkillTest = new EmployeeSkillTest();
            empSkillTest.AddEmpSkillTest();
            empSkillTest.GetAllAssociateDetailsTest();
            empSkillTest.UpdateEmpSkillTest();
            empSkillTest.DeleteEmpSkillTest();
        }
    }
}
