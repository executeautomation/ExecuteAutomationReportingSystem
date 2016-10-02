using Test_EARS_Service.Service;
namespace Test_EARS_Service
{
    class Program
    {
        static void Main(string[] args)
        {

            ServicesClient client = new ServicesClient();
            client.CreateTestCycle("Test For Demo", "Karthik", "Jacob", "2.0", "1", "Test Machine");

            client.WriteTestResult("New Feature", "New Scenario", "New Step", "", "PASSED");
            client.WriteTestResult("New Feature", "New Scenario1", "New Step2", "", "PASSED");
            client.WriteTestResult("New Feature", "New Scenario2", "New Step3", "", "FAILED");

        }
    }
}
