using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SinisterOffice666Wpf.Model
{
    public class MyCommand : ICommand
    {

        public Action _Execute;

        public MyCommand(Action ExecuteMethod)
        {
            _Execute = ExecuteMethod;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _Execute();
        }

    }
}
