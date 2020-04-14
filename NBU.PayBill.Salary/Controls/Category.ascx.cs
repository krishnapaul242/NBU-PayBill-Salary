using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBU.PayBill.Salary.BL.BusinessObjects;
using NBU.PayBill.Salary.BL.BusController;
namespace NBU.PayBill.Salary.Controls
{
    public partial class Category : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

            }
            else
            {
                CategoryBO categoryBO = new CategoryBO();
                categoryBO.CategoryName = this.uc_txt_Name.Text.Trim();
                categoryBO.CategoryID = categoryBO.CategoryName.First().ToString();
                if(EarningAndDeductionsBC.AddCategory(categoryBO) != -1)
                {

                }
            }
        }
    }
}