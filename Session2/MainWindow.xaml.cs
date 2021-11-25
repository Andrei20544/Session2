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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Session2
{
    public partial class MainWindow : Window
    {
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

                filtCombo.Items.Add("Все типы");

                foreach (var item in agentTypes.Distinct()) filtCombo.Items.Add(item.Title);

            }

            filtCombo.SelectedItem = "Все типы";
            ordCombo.SelectedItem = "up";

            DataContext = new MainViewModel();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (filtCombo.SelectedItem == null && ordCombo.SelectedItem == null)
                SetDataContext(SearchText.Text, "up", "");
            else if (filtCombo.SelectedItem == null)
                SetDataContext(SearchText.Text, ordCombo.SelectedItem.ToString(), "");
            else if (ordCombo.SelectedItem == null)
                SetDataContext(SearchText.Text, "up", filtCombo.SelectedItem.ToString());
            else
                SetDataContext(SearchText.Text, ordCombo.SelectedItem.ToString(), filtCombo.SelectedItem.ToString());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filtCombo.SelectedItem == null)
                SetDataContext(SearchText.Text, ordCombo.SelectedItem.ToString(), "");
            else
                SetDataContext(SearchText.Text, ordCombo.SelectedItem.ToString(), filtCombo.SelectedItem.ToString());
        }

        private void filtCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ordCombo.SelectedItem == null)
                SetDataContext(SearchText.Text, "up", filtCombo.SelectedItem.ToString());
            else
                SetDataContext(SearchText.Text, ordCombo.SelectedItem.ToString(), filtCombo.SelectedItem.ToString());
        }

        private void SetDataContext(string searchText, string ordComboText, string filtComboText)
        {
            DataContext = new MainViewModel(searchText, ordComboText, filtComboText);
        }
    }
}
