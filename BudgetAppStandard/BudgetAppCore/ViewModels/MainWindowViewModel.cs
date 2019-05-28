using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAppCore.ViewModels
{
    public class MainWindowViewModel : LocalBaseViewModel
    {
        private BillViewModel bvm;
        public BillViewModel BVM
        {
            get { return bvm; }
            set
            {
                if (bvm != value)
                {
                    bvm = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public MainWindowViewModel()
        {
            BVM = new BillViewModel();
        }

    }
}
