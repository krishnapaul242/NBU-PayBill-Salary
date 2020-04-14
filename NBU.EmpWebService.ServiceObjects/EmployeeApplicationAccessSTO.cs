using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBU.EmpWebService.ServiceObjects
{
    [Serializable]
    public class EmployeeApplicationAccessSTO : BaseSTO
    {
        public string EmpID { get; set; }
        public string AppID { get; set; }
        public string AppName { get; set; }
        public string AccessType { get; set; }
        public string AccessTypeCode { get; set; }
    }
}