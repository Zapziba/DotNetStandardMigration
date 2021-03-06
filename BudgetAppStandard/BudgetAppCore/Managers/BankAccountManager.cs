﻿using BudgetAppCore.Models;
using BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BudgetAppCore.Managers
{
    public class BankAccountManager
    {
        #region Singleton
        private static BankAccountManager instance;
        public static BankAccountManager Instance => instance ?? (instance = new BankAccountManager());
        
        private BankAccountManager() { }

        #endregion Singleton

        #region Properties
        public Dictionary<string, BankAccount> AccountsByNumber { get; set; } = new Dictionary<string, BankAccount>();
        public Dictionary<string, BankAccount> AccountsByID { get; set; } = new Dictionary<string, BankAccount>();
        public List<BankAccount> AllAccounts { get; set; } = new List<BankAccount>();

        public BankAccount SelectedAccount { get; set; }
        public int AccountCount { get; set; }

        //private BankAccount selectedAccount;
        //public BankAccount SelectedAccount
        //{
        //    get { return selectedAccount; }
        //    set
        //    {
        //        if (selectedAccount != value)
        //        {
        //            selectedAccount = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}


        //private int accountCount;
        //public int AccountCount
        //{
        //    get { return accountCount; }
        //    set
        //    {
        //        if (accountCount != value)
        //        {
        //            accountCount = value;
        //            NotifyPropertyChanged();
        //            Console.WriteLine($"bank accountnotify count = {AccountCount}");
        //        }
        //    }
        //}
        #endregion

        #region Methods
        private void UpdateAccountCount()
        {
            AccountCount = AllAccounts.Count;
        }

        public void AddAccount(BankAccount ba)
        {
            
            if (!AllAccounts.Contains(ba))
            {
                Console.WriteLine("bank account added");
                AccountsByNumber.Add(ba.Nickname, ba);
                AccountsByID.Add(ba.UniqueID, ba);
                AllAccounts.Add(ba);
                Console.WriteLine($"all accounts add count {AllAccounts.Count}");
            }
            UpdateAccountCount();
        }

        public void AddAccount(string name, string nickname, string uid, string acctNumber = "-", string bankName = "-")
        {
            Console.WriteLine("bank account added");
            if (!AccountsByNumber.ContainsKey(name) && !AccountsByID.ContainsKey(uid))
            {
                Console.WriteLine("bank account added");
                var acct = new BankAccount(0, acctNumber, bankName, nickname, uid);
                AddAccount(acct);
            }
            UpdateAccountCount();
        }

        public void RemoveAccount(BankAccount ba)
        {
            AllAccounts.Remove(ba);
            AccountsByNumber.Remove(ba.AccountNumber);
            AccountsByID.Remove(ba.UniqueID);
            UpdateAccountCount();
        }

        public void RemoveAccount(string name)
        {
            if(AccountsByNumber.TryGetValue(name, out var acct))
            {
                RemoveAccount(acct);
            }
            UpdateAccountCount();
        }

        public void Reset()
        {
            AccountsByNumber.Clear();
            AccountsByID.Clear();
            AllAccounts.Clear();
            SelectedAccount = null;
            UpdateAccountCount();
        }

        public void SwapAccountOrder(BankAccount ba1, BankAccount ba2)
        {
            if(AllAccounts.Contains(ba1) && AllAccounts.Contains(ba2))
            {
                var index2 = AllAccounts.IndexOf(ba2);
                AllAccounts.Remove(ba2);
                var index1 = AllAccounts.IndexOf(ba1);
                AllAccounts.Insert(index1, ba2);

                AllAccounts.Insert(index2, ba1);
            }

        }

        public void RemoveSelected(BankAccount ba)
        {
            AllAccounts.Remove(ba);
        }
        #endregion
        
    }
}
 