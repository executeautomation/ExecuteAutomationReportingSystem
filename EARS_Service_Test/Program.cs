using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EARS_Service_Test.Service;

namespace EARS_Service_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicesClient client = new ServicesClient();

            client.CreateTestCycle("TestClient", "Karthik", "Me", "1.0", "1", "Windows 10");

            client.WriteTestResult("FeatureNew", "New Scenario", "Test Step", "", "PASSED");
            client.WriteTestResult("FeatureNew", "New Scenario", "Test Step", "", "PASSED");
            client.WriteTestResult("FeatureNew", "New Scenario", "Test Step", "", "PASSED");
            client.WriteTestResult("FeatureNew", "New Scenario", "Test Step", "", "FAILED");


        }
    }
}
