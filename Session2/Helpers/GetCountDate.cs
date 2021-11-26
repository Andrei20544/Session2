using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Helpers
{
    public class CountDate
    {
        public int IDSale { get; set; }
        public int? Product_count { get; set; }
        public int? AgentID { get; set; }
    }

    public static class GetCountDate
    {
        private static List<CountDate> GetCountsOnYear()
        {

            try
            {
                List<CountDate> countDates = new List<CountDate>();

                using (ModelBD model = new ModelBD())
                {

                    var product_sale = from ps in model.ProductSale
                                       select ps;
                    DateTime date_now = DateTime.Now;
                    DateTime date = new DateTime();
                    TimeSpan time = new TimeSpan();
                    CountDate countDate = null;

                    foreach (var item in product_sale)
                    {
                        date = item.SaleDate.Value;
                        time = date_now - date;
                        if (time.Days <= 365)
                        {
                            countDate = new CountDate();
                            countDate.IDSale = item.ID;
                            countDate.Product_count = item.ProductCount;
                            countDate.AgentID = item.AgentID;

                            countDates.Add(countDate);
                        }
                    }

                    return countDates;
                }

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static int? GetCountOnYear(int? agent_id)
        {

            try
            {
                int? res = 0;

                if (GetCountsOnYear() != null)
                {
                    foreach (var item in GetCountsOnYear())
                    {
                        if (item.AgentID == agent_id) res += item.Product_count;
                    }
                }

                return res;

            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
