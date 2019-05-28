using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BaseClasses
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        #region Constructors
        

        public DelegateCommand(Action execute) : this(execute, null) { }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion


        #region ICommand
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(_canExecute != null)
            {
                return _canExecute();
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }
        #endregion

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        
    }
}


















//public interface IDelegateCommandHelper
//{
//    event EventHandler CanExecuteChanged;
//    void RaiseCanExecuteChanged(object sender);


//}

//public class WeakCommandHelper : IDelegateCommandHelper
//{
//    private readonly List<WeakReference> _eventHandlers = new List<WeakReference>();
//    private readonly object _syncRoot = new object();

//    public event EventHandler CanExecuteChanged
//    {
//        add
//        {
//            lock (_syncRoot)
//            {
//                _eventHandlers.Add(new WeakReference(value));
//            }
//        }

//        remove
//        {
//            lock (_syncRoot)
//            {
//                foreach(var thing in _eventHandlers)
//                {
//                    var target = thing.Target;
//                    if(target != null && (EventHandler)target == value)
//                    {
//                        _eventHandlers.Remove(thing);
//                        break;
//                    }
//                }
//            }
//        }
//    }

//    private IEnumerable<EventHandler> SafeCopyEventHandlerList()
//    {
//        lock (_syncRoot)
//        {
//            var toReturn = new List<EventHandler>();
//            var deadEntries = new List<WeakReference>();

//            foreach (var thing in _eventHandlers)
//            {
//                if (!thing.IsAlive)
//                {
//                    deadEntries.Add(thing);
//                    continue;
//                }
//                var eventHandler = (EventHandler)thing.Target;
//                if (eventHandler != null)
//                {
//                    toReturn.Add(eventHandler);
//                }
//            }

//            foreach (var weakReference in deadEntries)
//            {
//                _eventHandlers.Remove(weakReference);
//            }

//            return toReturn;
//        }
//    }

//    public void RaiseCanExecuteChanged(object sender)
//    {
//        var list = SafeCopyEventHandlerList();
//        foreach(var eventHandler in list)
//        {
//            eventHandler(sender, EventArgs.Empty);
//        }
//    }
//}


//public class DelegateCommand
//{
//    Action _execute;
//    Func<bool> _canExecute;
//    private readonly IDelegateCommandHelper _commandHelper;

//    public DelegateCommand(Action execute) : this(execute, null) { }

//    public DelegateCommand(Action execute, Func<bool> canExecute)
//    {
//        _execute = execute;
//        _canExecute = canExecute;
//        _commandHelper = new WeakCommandHelper();
//    }

//    public void RaiseCanExecuteChanged()
//    {
//        _commandHelper.RaiseCanExecuteChanged(this);//,EventArgs.Empty);
//    }

//    public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
//    //{
//    //    if( _canExecute != null )
//    //    {
//    //        return _canExecute();
//    //    }
//    //    if( _canExecute == null )
//    //    {
//    //        return true;
//    //    }
//    //    return false;
//    //}

//    //private EventHandler eventHandler;

//    public event EventHandler CanExecuteChanged
//    {
//        add
//        {
//            _commandHelper.CanExecuteChanged += value;
//        }
//        remove
//        {
//            _commandHelper.CanExecuteChanged -= value;
//        }
//    }

//    private void Execute(object parameter)
//    {
//        if (CanExecute(parameter))
//        {
//            _execute();
//        }
//    }

//}