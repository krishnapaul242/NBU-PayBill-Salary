using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBU.PayBill.Salary.BL.DataAccessService;
using NBU.PayBill.Salary.BL.BusinessObjects;
using NBU.Common.Helper;

namespace NBU.PayBill.Salary.BL.BusController
{
    public static class EarningAndDeductionsBC
    {
        public static List<CategoryBO> GetCategoryBOs()
        {
            EarningAndDeductionsDAS earningAndDeductionsDAS = new EarningAndDeductionsDAS();
            string jsondata = earningAndDeductionsDAS.GetAllCategories();
            List<CategoryBO> categoryBOs = new List<CategoryBO>();
            if (!jsondata.StartsWith("DB_ERROR"))
                categoryBOs = StringUtil.DeserializeObjectFromJSON<List<CategoryBO>>(jsondata);
            else
                categoryBOs = null;
            return categoryBOs;
        }

        public static bool AddCategory(CategoryBO categoryBO)
        {
            EarningAndDeductionsDAS earningAndDeductionsDAS = new EarningAndDeductionsDAS();
            int result = earningAndDeductionsDAS.AddNewCategory(categoryBO);
            return result > 0;
        }

        public static bool UpdateCategory(CategoryBO categoryBO)
        {
            EarningAndDeductionsDAS earningAndDeductionsDAS = new EarningAndDeductionsDAS();
            int numberOfRowImpacted = 0;
            numberOfRowImpacted = earningAndDeductionsDAS.UpdateCategory(categoryBO);
            return numberOfRowImpacted > 0;
        }
    }
}
