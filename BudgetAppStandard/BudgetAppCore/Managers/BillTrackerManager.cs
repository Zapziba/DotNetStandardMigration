using BudgetAppCore.Models;
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
    public class BillTrackerManager
    {
        #region Singleton
        private static BillTrackerManager instance;
        public static BillTrackerManager Instance
        {
            get { return instance ?? (instance = new BillTrackerManager()); }
        }

        private BillTrackerManager() { }
        #endregion Singleton

        #region Properties
        public Dictionary<string, BillTracker> TrackersByCompany { get; set; } = new Dictionary<string, BillTracker>();
        public List<BillTracker> AllTrackers { get; set; } = new List<BillTracker>();

        public BillTracker SelectedTracker { get; set; }
        public int TrackerCount { get; set; }

        //private BillTracker selectedTracker;
        //public BillTracker SelectedTracker
        //{
        //    get { return selectedTracker; }
        //    set
        //    {
        //        if (selectedTracker != value)
        //        {
        //            selectedTracker = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}


        //private int trackerCount;
        //public int TrackerCount
        //{
        //    get { return trackerCount; }
        //    set
        //    {
        //        if (trackerCount != value)
        //        {
        //            trackerCount = value;
        //            NotifyPropertyChanged();
        //            Console.WriteLine($"bill tracker notify count = {TrackerCount}");
        //        }
        //    }
        //}

        #endregion

        #region Methods
        private void UpdateTrackerCount()
        {
            TrackerCount = AllTrackers.Count;
        }

        public void AddTracker(BillTracker bt)
        {
            if (!AllTrackers.Contains(bt))
            {
                TrackersByCompany.Add(bt.CompanyName, bt);
                AllTrackers.Add(bt);
            }
            UpdateTrackerCount();
        }

        public void AddTracker(string name, List<Bill> bills)
        {
            if (!TrackersByCompany.ContainsKey(name))
            {
                var tracker = new BillTracker(name, bills);
            }
            UpdateTrackerCount();
        }

        public void RemoveTracker(BillTracker bt)
        {
            AllTrackers.Remove(bt);
            TrackersByCompany.Remove(bt.CompanyName);
            UpdateTrackerCount();
        }

        public void RemoveTracker(string name)
        {
            if(TrackersByCompany.TryGetValue(name, out var tracker))
            {
                RemoveTracker(tracker);
            }
            UpdateTrackerCount();
        }

        public void Reset()
        {
            TrackersByCompany.Clear();
            AllTrackers.Clear();
            SelectedTracker = null;
            UpdateTrackerCount();
        }
        #endregion
    }
}
 