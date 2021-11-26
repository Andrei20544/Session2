using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Session2.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DopAgent> Agents { get; set; }

        private DopAgent _selectedAgent;
        public DopAgent SelectedAgent
        {
            get
            {
                //try
                //{
                //    using (ModelBD model = new ModelBD())
                //    {
                //        var agents = from a in model.Agent
                //                     select a;

                //        var agent = agents.Where(id => id.ID == _selectedAgent.ID).FirstOrDefault();

                //        OnProppertyChanged();

                //        return agent;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    return null;
                //}
                return _selectedAgent;
            }
            set { _selectedAgent = value; OnProppertyChanged(); }
        }

        public ICommand SearchCommand { get; set; }

        public MainViewModel(string title = "", string ordBy = "up", string filt = "Все типы")
        {
            Agents = new ObservableCollection<DopAgent>(GetAgents.GetAgentsM(title, ordBy, filt));
            SearchCommand = new DelegateCommands(SearchAgent);
        }

        private void SearchAgent(object obj)
        {



        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProppertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
