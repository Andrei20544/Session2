using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Session2.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Agent[] _agents;
        public ObservableCollection<DopAgent> Agents { get; set; }

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
