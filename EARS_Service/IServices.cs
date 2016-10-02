using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EARS_Service
{
    [ServiceContract]
    public interface IServices
    {

        [OperationContract]
        void CreateTestCycle(string aut, string executedBy, string requestedBy, string buildNo, string appVersion, string machineName);

        [OperationContract]
        void WriteTestResult(string featureName, string scenarioName, string stepName, string exception, string result);

    }
}
