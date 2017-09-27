using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using EthernetConnection.Pages;
using System.Net;
using System.Net.Sockets;
using EthernetConnection.GlobalChannel;

namespace EthernetConnection.ViewModel
{
    public class Et_vm : INotifyPropertyChanged
    {
        private Page _page;
        public Page Page
        {
            get { return _page; }
            set
            {
                _page = value;
                OnPropertyChanged("Page");
            }
        }

        private TcpClient _Tcpclient = new TcpClient();
        public TcpClient Tcpclient
        {
            get { return _Tcpclient; }
            set
            {
                _Tcpclient = value;
                OnPropertyChanged("Tcpclient");
            }
        }

        private NetworkStream _netstream ;
        public NetworkStream Netstream
        {
            get { return _netstream; }
            set
            {
                _netstream = value;
                OnPropertyChanged("Netstream");
            }
        }

        private BackgroundWorker _worker;
        public BackgroundWorker Worker
        {
            get { return _worker; }
            set
            {
                _worker = value;
                OnPropertyChanged("Worker");
            }
        }

        private bool _m_continous = true;
        public bool M_continous
        {
            get { return _m_continous; }
            set
            {
                _m_continous = value;
                OnPropertyChanged("M_continous");
            }
        }

        private string[] _tstr;
        public string[] TStr
        {
            get { return _tstr; }
            set
            {
                _tstr = value;
                OnPropertyChanged("TStr");
            }
        }

        private string[] _str;
        public string[] Str
        {
            get { return _str; }
            set
            {
                _str = value;
                OnPropertyChanged("Str");
            }
        }

        private string _Watt_str="0";
        public string Watt_str
        {
            get { return _Watt_str; }
            set
            {
                _Watt_str = value;
                OnPropertyChanged("Watt_str");
            }
        }

        private string _port_str;
        public string Port_str
        {
            get { return _port_str; }
            set
            {
                _port_str = value;
                OnPropertyChanged("Port_str");
            }
        }

        private string _IP_str;
        public string IP_str
        {
            get { return _IP_str; }
            set
            {
                _IP_str = value;
                OnPropertyChanged("IP_str");
            }
        }

        private string _status_str = "Disconnected";
        public string Status_str
        {
            get { return _status_str; }
            set
            {
                _status_str = value;
                OnPropertyChanged("Status_str");
            }
        }

        private string _connect_str;
        public string Connect_str
        {
            get { return _connect_str; }
            set
            {
                _connect_str = value;
                OnPropertyChanged("Connect_str");
            }
        }

        private bool _pilot_status;
        public bool Pilot_status
        {
            get { return _pilot_status; }
            set
            {
                _pilot_status = value;
                OnPropertyChanged("Pilot_status");
            }
        }

        private bool _IR_status;
        public bool IR_status
        {
            get { return _IR_status; }
            set
            {
                _IR_status = value;
                OnPropertyChanged("IR_status");
            }
        }

        private string _key;
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged("Key");
            }
        }

        private BackgroundWorker _bw = new BackgroundWorker();
        public BackgroundWorker BW
        {
            get { return _bw; }
            set
            {
                _bw = value;
                OnPropertyChanged("BW");
            }
        }

        private string _set_power = "10";
        public string Set_power
        {
            get { return _set_power; }
            set
            {
                _set_power = value;
                OnPropertyChanged("Set_power");
            }
        }

        private string _pulse_width = "1.1";
        public string Pulse_width
        {
            get { return _pulse_width; }
            set
            {
                _pulse_width = value;
                OnPropertyChanged("Pulse_width");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
