using BudgetAppCore.Managers;
using BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAppCore.ViewModels
{
    public class LocalBaseViewModel : BaseViewModel
    {
        public BillTrackerManager BillTrackerManager => BillTrackerManager.Instance;
        public BankAccountManager BankAccountManager => BankAccountManager.Instance;

        public void ResetManagers()
        {
            BillTrackerManager.Reset();
            BankAccountManager.Reset();
        }

        public virtual void UpdateView() { }

    }

}
