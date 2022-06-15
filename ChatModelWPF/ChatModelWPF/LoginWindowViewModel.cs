using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatModelWPF
{
    class LoginWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _name;
        string _ip;
        public LoginWindowViewModel ()
        {
            Name = "Muchacho";
            IP = "127.0.0.1";
        }
        void Notify (string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Name
        {
            get { return _name; }
            set { _name = value;
                ChatUser.Name = _name; // если мы меняем имя, то онон меняется и в статичном классе
                Notify("Name");
            }
        }
        public string IP
        {
            get { return _ip; }
            set { _ip = value;
                ChatUser.IP = _ip;
                Notify("IP");
            }
        }
    }
}