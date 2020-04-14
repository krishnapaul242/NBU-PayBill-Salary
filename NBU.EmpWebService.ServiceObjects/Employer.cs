using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBU.EmpWebService.ServiceObjects
{
    [Serializable]
    public class Employer : BaseSTO
    {
        private string employerName;
        public string EmployerName
        {
            get { return employerName; }
            set { employerName = value; }
        }

        private string employerAddress;

        public string EmployerAddress
        {
            get { return employerAddress; }
            set { employerAddress = value; }
        }

        private string employerContactNo;

        public string EmployerContactNo
        {
            get { return employerContactNo; }
            set { employerContactNo = value; }
        }


        private string employerEmail;
        public string EmployerEmail
        {
            get { return employerEmail; }
            set { employerEmail = value; }
        }


        private string employerTAN;

        public string EmployerTAN
        {
            get { return employerTAN; }
            set { employerTAN = value; }
        }



        private string employerPAN;

        public string EmployerPAN
        {
            get { return employerPAN; }
            set { employerPAN = value; }
        }
        

    }
}
