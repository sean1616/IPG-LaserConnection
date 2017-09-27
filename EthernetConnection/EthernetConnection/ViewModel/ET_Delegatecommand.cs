using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EthernetConnection.ViewModel
{
    class ET_Delegatecommand : ICommand
    {
        private readonly Action _action;

        //Constructor
        public ET_Delegatecommand(Action action)
        {

            _action = action;
        }

        //執行Action
        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged { add { } remove { } } //what's this ??
#pragma warning restore 67
    }
}
