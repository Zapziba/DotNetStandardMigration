using System;
using System.Windows.Input;

namespace BaseClasses
{
    public class DelegateCommandFramework// : ICommand
    {
        //Action _TargetExecuteMethod;
        //Func<bool> _TargetCanExecuteMethod;

        //public DelegateCommandFramework(Action executeMethod)
        //{
        //    _TargetExecuteMethod = executeMethod;
        //}

        //public DelegateCommandFramework(Action executeMethod, Func<bool> canExecuteMethod)
        //{
        //    _TargetExecuteMethod = executeMethod;
        //    _TargetCanExecuteMethod = canExecuteMethod;
        //}

        //public void RaiseCanExecuteChanged()
        //{
        //    CommandManager.InvalidateRequerySuggested();//CanExecuteChanged(this, EventArgs.Empty);
        //}

        //bool ICommand.CanExecute(object parameter)
        //{

        //    if (_TargetCanExecuteMethod != null)
        //    {
        //        return _TargetCanExecuteMethod();
        //    }

        //    if (_TargetExecuteMethod != null)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //// Beware - should use weak references if command instance lifetime 
        //// is longer than lifetime of UI objects that get hooked up to command

        //// Prism commands solve this in their implementation 
        ////public event EventHandler CanExecuteChanged = delegate { };
        //private EventHandler eventHandler;
        //public event EventHandler CanExecuteChanged
        //{
        //    add
        //    {
        //        eventHandler += value;
        //        CommandManager.RequerySuggested += value;
        //    }
        //    remove
        //    {
        //        eventHandler -= value;
        //        CommandManager.RequerySuggested -= value;
        //    }
        //}

        //void ICommand.Execute(object parameter)
        //{
        //    _TargetExecuteMethod?.Invoke();
        //}

    }
}
