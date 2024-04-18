using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
namespace Employee_Details.Commands
{
    class MyCommand:ICommand
        {
        //event func helps to call method having parameter and last parameter is out parameter
        Func<object, bool> canExecuteMethod;
    //action event helps to call method 
    Action<object> executeMethod;

    public MyCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod = null)
    {
        this.canExecuteMethod = canExecuteMethod;
        this.executeMethod = executeMethod;
    }
    public bool CanExecute(object parameter)
    {
        return true;

    }


     public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
    {
        executeMethod(parameter);
    }
   
   
    }
}
