using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Session2.ViewModels
{
    public static class GetAgents
    {
        public static DopAgent[] GetAgentsM(string title = "", string ordBy = "up", string filt = "Все типы")
        {
            try
            {
                using (ModelBD model = new ModelBD())
                {

                    var agents = from a in model.Agent
                                 where a.Title.Contains(title) || a.Email.Contains(title) || a.Phone.Contains(title)
                                 select a;

                    var productSale = from ps in model.ProductSale
                                      select ps;

                    var agetTypes = from at in model.AgentType
                                    select at;

                    DopAgent dopAgent = null;
                    List<DopAgent> dopList = new List<DopAgent>();
                    BitmapImage bitmapImage = null;

                    string type = "";

                    foreach (var item in productSale)
                    {

                        foreach (var agent in agents)
                        {

                            if (item.AgentID.Equals(agent.ID))
                            {
                                dopAgent = new DopAgent();

                                int? id = agent.AgentTypeID;
                                type = agetTypes.Where(at => at.ID == id).FirstOrDefault().Title;

                                dopAgent.Title = type + " | " + agent.Title;
                                dopAgent.Phone = agent.Phone;
                                dopAgent.Date = "2020";
                                dopAgent.Percent = 10;
                                dopAgent.Priority = 10;

                                Uri img = null;

                                if (agent.Logo == "не указано" || agent.Logo == "нет" || agent.Logo == "отсутствует") img = new Uri("Resources/agents/picture.png", UriKind.Relative);
                                else img = new Uri("Resources" + agent.Logo.Replace("\\", "/"), UriKind.Relative);

                                bitmapImage = new BitmapImage(img);

                                dopAgent.Img = bitmapImage;

                                if (!filt.Equals("Все типы"))
                                {
                                    if (filt.Equals(type)) dopList.Add(dopAgent);
                                }
                                else if (filt.Equals("Все типы"))
                                {
                                    dopList.Add(dopAgent);
                                }
                                    
                            }

                        }

                    }

                    return GetSortAgents(dopList, ordBy);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private static DopAgent[] GetSortAgents(List<DopAgent> dopAgents, string by = "up")
        {
            if (by == "up") return dopAgents.OrderBy(t => t.Title).ToArray();
            else if (by == "down") return dopAgents.OrderByDescending(t => t.Title).ToArray();
            else if (by == "none") return dopAgents.ToArray();

            return null;
        }
    }
}
