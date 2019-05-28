using System;
using System.Collections.Generic;
using System.Text;

namespace BaseClasses
{
    public interface INavigationParentViewModel<T> : IDisposable where T : NavigationMessage, new()
    {
        INavigationViewModel CurrentViewModel { get; set; }

        void EnableNavigation();
        void DisableNavigation();
        new void Dispose();
    }
}
