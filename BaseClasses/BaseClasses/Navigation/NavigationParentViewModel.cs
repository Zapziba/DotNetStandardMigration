using System;
using System.Collections.Generic;
using System.Text;

namespace BaseClasses
{
    public class NavigationParentViewModel<T> : BaseViewModel, INavigationParentViewModel<T> where T : NavigationMessage, new()
    {

        private INavigationViewModel currentViewModel;
        public INavigationViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                if (currentViewModel != value)
                {
                    currentViewModel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public NavigationParentViewModel()
        {
            EnableNavigation();
        }


        public void DisableNavigation()
        {
            Messenger.Default.Unregister(typeof(T), this);
        }

        public void Dispose()
        {
            DisableNavigation();
        }

        public void EnableNavigation()
        {

            Messenger.Default.Register<T>(typeof(T), x => this.CurrentViewModel = (x as NavigationMessage)?.NavigateToViewModel);
        }
    }
}
