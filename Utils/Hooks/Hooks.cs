namespace SpecFlowProject_QA_MARS.Utils.Hooks
{
    [Binding]
    public sealed class Hooks : Driver
    {
        [BeforeScenario]

        public void Before_Scenario()
        {
            Initialize();

        }


        [AfterScenario]

        public void After_Scenario()
        {
            driver.Quit();
        }

    }
}
