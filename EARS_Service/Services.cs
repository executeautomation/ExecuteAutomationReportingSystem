using System.ServiceModel;

namespace EARS_Service
{
    [ServiceContract]
    public interface IServices
    {

        [OperationContract]
        void CreateTestCycle(string aut, string executedBy, string requestedBy, string buildNo, string appVersion, string machineName);


        [OperationContract]
        void WriteTestResult(string featureName, string scenarioName, string stepName, string Exception, string Result);
    }

}
