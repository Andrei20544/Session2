using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Session2.ViewModels
{
    public class DopAgent : INotifyPropertyChanged
    {
        private int? _ID { get; set; }
        public int? ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnProppertyChanged();
            }
        }

        private string _title { get; set; }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnProppertyChanged();
            }
        }

        private string _type { get; set; }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnProppertyChanged();
            }
        }

        private string _date { get; set; }
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnProppertyChanged();
            }
        }

        private string _phone { get; set; }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnProppertyChanged();
            }
        }

        private double? _priority { get; set; }
        public double? Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                OnProppertyChanged();
            }
        }

        private double _percent { get; set; }
        public double Percent
        {
            get { return _percent; }
            set
            {
                _percent = value;
                OnProppertyChanged();
            }
        }

        private BitmapImage _img { get; set; }
        public BitmapImage Img
        {
            get { return _img; }
            set
            {
                _img = value;
                OnProppertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProppertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
