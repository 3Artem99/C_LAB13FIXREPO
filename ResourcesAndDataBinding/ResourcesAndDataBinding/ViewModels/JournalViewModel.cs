using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace ResourcesAndDataBinding.ViewModels
{
    public class JournalViewModel
    {
        public ObservableCollection<Journal> Journals { get; set; }

        public Journal SelectedJournal { get; set; }

        public JournalViewModel()
        {
            this.Journals = new ObservableCollection<Journal>();
            Journals = new ObservableCollection<Journal>();
            Journal j1 = new Journal
            {
                journalID = 1,
                pages = 111,
                name = "A"
            };
            Journal j2 = new Journal
            {
                journalID = 2,
                pages = 222,
                name = "B"
            };
            Journal j3 = new Journal
            {
                journalID = 3,
                pages = 333,
                name = "C"
            };

            Journals.Add(j1);
            Journals.Add(j2);
            Journals.Add(j3);
        }
    }
}
