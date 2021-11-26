using Session2.Helpers;
using Session2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Session2.Views
{
    public partial class ChangeWindow : Window
    {
        private Agent _agent = null;

        public ChangeWindow()
        {
            InitializeComponent();
        }

        public ChangeWindow(object dataContext)
        {
            InitializeComponent();
            var agent_ID = (dataContext as MainViewModel).SelectedAgent.ID;

            try
            {
                using (ModelBD model = new ModelBD())
                {

                    var agents = from a in model.Agent
                                 select a;

                    var agent_types = from at in model.AgentType
                                      select at;

                    var agent = agents.Where(a => a.ID == agent_ID).FirstOrDefault();
                    var agent_type = agent_types.Where(a => a.ID == agent.AgentTypeID).FirstOrDefault();

                    _agent = agent;

                    IDText.Text = "ID: " + agent.ID;

                    CompanyLogo.Source = ProcessIMG.GetBitmapImage(agent, "/");

                    TitleText.Text = agent.Title;
                    AgentTypeText.Text = agent_type.Title;
                    Adress.Text = agent.Address;
                    INNText.Text = agent.INN;
                    KPPText.Text = agent.KPP;
                    DirNameText.Text = agent.DirectorName;
                    PhoneText.Text = agent.Phone;
                    EmailText.Text = agent.Email;
                    PriorityText.Text = agent.Priority.ToString();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Agent agent = null;

                using (ModelBD model = new ModelBD())
                {

                    var agents = from a in model.Agent
                                 select a;

                    agent = agents.Where(a => a.ID == _agent.ID).FirstOrDefault();

                    model.Agent.Remove(agent);
                    model.Entry(agent).State = System.Data.Entity.EntityState.Modified;

                    model.SaveChanges();
                }

                MessageBox.Show("Агент удален из базы данных");
                this.DialogResult = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не удалось удалить агента" + $"\n \n{ex.Message}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Agent agent = null;

                using (ModelBD model = new ModelBD())
                {
                    int? id = int.Parse(IDText.Text.Split(':')[1]);

                    agent = model.Agent.Where(a => a.ID == id).FirstOrDefault();
                    agent.Title = TitleText.Text;
                    agent.Address = Adress.Text;
                    agent.INN = INNText.Text;
                    agent.KPP = KPPText.Text;
                    agent.DirectorName = DirNameText.Text;
                    agent.Phone = PhoneText.Text;
                    agent.Email = EmailText.Text;
                    agent.Priority = int.Parse(PriorityText.Text);

                    model.Entry(agent).State = System.Data.Entity.EntityState.Modified;

                    model.SaveChanges();
                }

                MessageBox.Show("Агент изменен из базы данных");
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось изменить агента" + $"\n \n{ex.Message}");
            }
        }
    }
}
