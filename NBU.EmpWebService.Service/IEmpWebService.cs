using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NBU.EmpWebService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmpWebService" in both code and config file together.
    [ServiceContract]
    public interface IEmpWebService
    {
        [OperationContract]
        string IsValidUser(string userID, string userPassword, string applicationID);

        [OperationContract]
        string GetEmpAccessByApplication(string empId, string appId);

        [OperationContract]
        string GetEmpDetailByEmpId(string empId);

        [OperationContract]
        string GetActiveEmployeeList();

        [OperationContract]
        string GetEmpDependentListByEmpID(string empId);

        [OperationContract]
        string GetEmployerDetail();

    }
}
