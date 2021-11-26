using Session2.Helpers;
using Session2.ViewModels;
using Session2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Session2
{
    public partial class MainWindow : Window
    {
        private int _count_agents = 0;
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 3; i++) ordCombo.Items.Add(Names.GetStr(i));

            using (ModelBD model = new ModelBD())
            {

                var agentTypes = from at in model.AgentType
                                 select new
                                 {
                                     Title = at.Title
                                 };

                foreach (var item in agentTypes.Distinct()) filtCombo.Items.Add(item.Title);

                _count_agents = model.Agent.Count();

            }

            filtCombo.Items.Add("Все типы");
            filtCombo.SelectedItem = "Все типы";
            ordCombo.SelectedItem = "up";

            DataContext = new MainViewModel();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => LogicDataContext();

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => LogicDataContext();

        private void filtCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) => LogicDataContext();

        private void LogicDataContext()
        {

            if (filtCombo.SelectedItem == null && ordCombo.SelectedItem == null)
                SetDataContext(SearchText.Text, "up", "");
            else if (filtCombo.SelectedItem == null)
                SetDataContext(SearchText.Text, ordCombo.SelectedItem.ToString(), "");
            else if (ordCombo.SelectedItem == null)
                SetDataContext(SearchText.Text, "up", filtCombo.SelectedItem.ToString());
            else
                SetDataContext(SearchText.Text, ordCombo.SelectedItem.ToString(), filtCombo.SelectedItem.ToString());

            this.Title = $"Agents | Count: {_count_agents}";

        }

        private void SetDataContext(string searchText, string ordComboText, string filtComboText)
        {
            DataContext = null;
            DataContext = new MainViewModel(searchText, ordComboText, filtComboText);
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeWindow changeWindow = new ChangeWindow(DataContext);
            if (changeWindow.ShowDialog() == true)
            {
                LogicDataContext();
            }
        }
    }
}
