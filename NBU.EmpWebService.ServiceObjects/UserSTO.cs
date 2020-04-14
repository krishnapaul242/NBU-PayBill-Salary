using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBU.EmpWebService.ServiceObjects
{
    [Serializable]
    public class UserSTO : BaseSTO
    {
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public string EmpId { get; set; }
        public string Name { get; set; }
    }
}
