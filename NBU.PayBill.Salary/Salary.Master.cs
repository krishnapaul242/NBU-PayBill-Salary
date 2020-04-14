using NBU.EmpWebService.ServiceObjects;
using NBU.EmpWebService.Service;
using System;

namespace NBU.PayBill.Salary
{
    public partial class Salary : System.Web.UI.MasterPage
    {
        EmployeeSTO empDetail
        {
            get
            {
                if (ViewState["empDetail"] == null)
                {
                    EmpWebService.EmpWebServiceClient serviceTestClient = new EmpWebService.EmpWebServiceClient();
                    string userDetXML = serviceTestClient.GetEmpDetailByEmpId(NBU.Common.Helper.StringUtil.Encode((((UserSTO)Session["LoggedInUser"])).EmpId));
                    ViewState["empDetail"] = NBU.Common.Helper.StringUtil.DeserializeObjectFromXML(userDetXML, typeof(EmployeeSTO));
                }
                return (EmployeeSTO)ViewState["empDetail"];
            }

        }

        Employer employer
        {
            get
            {
                if (Session["employer"] == null)
                {
                    EmpWebService.EmpWebServiceClient serviceTestClient = new EmpWebService.EmpWebServiceClient();
                    string employerXML = serviceTestClient.GetEmployerDetail();
                    Session["employer"] = NBU.Common.Helper.StringUtil.DeserializeObjectFromXML(employerXML, typeof(Employer));
                }
                return (Employer)Session["employer"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblEmployerName.Text = employer.EmployerName;
            
        }
    }
}