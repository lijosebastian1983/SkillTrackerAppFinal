using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using SkillTrackerTest;

namespace SkillTrackerNBenchTest
{
    public class NBenchSkillTest
    {
        [PerfBenchmark(NumberOfIterations =1, RunMode =RunMode.Iterations, 
            TestMode =TestMode.Test,SkipWarmups =true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds =10000)]
        public void BenchMarkPerformanceSkill()
        {
            SkillTest skillTest = new SkillTest();
            skillTest.AddSkillTest();
            skillTest.GetAllSkillsTest();
            skillTest.UpdateSkillTest();
            skillTest.DeleteSkillTest();
        }
    }
}
