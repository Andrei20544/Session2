using Session2.Helpers;
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

                    var agetTypes = from at in model.AgentType
                                    select at;

                    DopAgent dopAgent = null;
                    List<DopAgent> dopList = new List<DopAgent>();

                    string type = "";

                    if (agents != null)
                    {
                        foreach (var agent in agents)
                        {

                            dopAgent = new DopAgent();

                            int? id = agent.AgentTypeID;
                            
                            if (agetTypes != null)
                            {
                                //type = agetTypes.Where(at => at.ID == id).FirstOrDefault().Title;
                            }

                            dopAgent.ID = agent.ID;
                            dopAgent.Title = type + " | " + agent.Title;
                            dopAgent.Phone = agent.Phone;
                            dopAgent.Date = GetCountDate.GetCountOnYear(agent.ID).ToString() + " продаж за год";
                            dopAgent.Percent = 10;
                            dopAgent.Priority = agent.Priority;
                            dopAgent.Img = ProcessIMG.GetBitmapImage(agent);

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

                    return GetSortAgents(dopList, ordBy);
                }
            }
            catch (Exception ex)
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
