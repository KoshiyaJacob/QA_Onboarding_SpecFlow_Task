using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V119.Profiler;
using SpecFlowProject_QA_MARS.Pages;

namespace SpecFlowProject_QA_MARS.Utils.Hooks
{
    [Binding]
    public sealed class Hooks: Start
    {
        [BeforeScenario]
       
        public void Before_Scenario()
        {
            Setup();
           
        }

            
        [AfterScenario]

        public void After_Scenario()
        {
            TearDown();
        }

    }
}
