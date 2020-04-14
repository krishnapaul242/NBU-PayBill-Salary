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
    public partial class AddNewEarning : System.Web.UI.UserControl
    {
        private string Title;

        public string GetTitle()
        {
            return Title;
        }

        public void SetTitle(string value)
        {
            Title = value;
        }

        private List<CategoryBO> categoryBOs
        {
            get
            {
                if(ViewState["categories"] == null)
                    ViewState["categories"] = EarningAndDeductionsBC.GetCategoryBOs();
                return (List<CategoryBO>)ViewState["categories"];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.uc_lbl_title.Text = "Add New " + this.GetTitle();
            this.uc_lbl_fixedOrVarriable.Text = "Is this "+ this.GetTitle() +" fixed or a percentage of basic salary?";
            if (!IsPostBack)
            {
                this.uc_ddl_categories.DataTextField = "CategoryName";
                this.uc_ddl_categories.DataValueField = "CategoryID";
                this.uc_ddl_categories.DataSource = categoryBOs;
                this.uc_ddl_categories.DataBind();
            }
            else
            {
                //Implementing postback process
                
            }
        }
    }
}