using System;
using System.Collections.Generic;
using System.Text;

namespace BaseClasses.Navigation
{
    public interface INavigable
    {
        void Activate(object parameter);
        void Deactivate(object parameter);
    }
}
