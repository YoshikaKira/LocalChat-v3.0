using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace ChatModelWPF
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection <string> _messagesHistory;
        string _message;
        ServerConnection _connection;
        Dispatcher _dispatcher;
        string[] _userList;
        public string[] UserList
        {
            get { return _userList; }
            set
            {
                _userList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserList"));
            }
        }
        void ServerListener ()
        {
            while (_connection.Client.Connected)
            {
                string message = _connection.GetMessage();
                if (message != "")
                {
                    if (message.IndexOf("<USERLIST>") == 0)
                    {
                        message.Remove(0, 10);
                        UserList = message.Split('|');
                    }
                    else
                    {
                        _dispatcher.Invoke(() => MessagesHistory.Add(message));
                    }
                }
            }
        }
        public ViewModel ()
        {
            _messagesHistory = new ObservableCollection<string>();
            LoginWindow login = new LoginWindow();
            login.ShowDialog();

            _connection = new ServerConnection(ChatUser.IP);
            _connection.SendMessage("<NAME>" + ChatUser.Name);
            _dispatcher = Dispatcher.CurrentDispatcher;
            Task task = new Task(ServerListener);
            task.Start();
        }
        public ICommand SendBtn
        {
            get { return new ButtonCommand(() => _connection.SendMessage(_message));
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                Notify("Message");
            }
        }
        void Notify (string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<string> MessagesHistory
        {
            get { return _messagesHistory; }
            set {
                _messagesHistory = value;
                Notify("MessagesHistory");
            }
        }
    }
}