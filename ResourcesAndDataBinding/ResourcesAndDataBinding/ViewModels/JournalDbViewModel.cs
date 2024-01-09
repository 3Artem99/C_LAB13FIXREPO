using ResourcesAndDataBinding.DataAccess;
using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ResourcesAndDataBinding.ViewModels
{
    public class JournalDbViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Journal> Journals { get; set; }

        private Journal _selectedJournal;
        public Journal SelectedJournal
        {
            get
            {
                return _selectedJournal;
            }
            set
            {
                _selectedJournal = value;
                OnPropertyChanged();
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

        public Command AddCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public Command SaveAllCommand { get; set; }

        public JournalsDataAccess JournalsDataBase;

        private void LoadData()
        {
            Journals = new ObservableCollection<Journal>
                ();
        }

        public JournalDbViewModel()
        {
            JournalsDataBase = new JournalsDataAccess();
            LoadData();

            AddCommand =
                new Command(() => Journals.Add(new Journal()));

            DeleteCommand =
                new Command<Journal>((journal) =>
                {
                    Journals.Remove(journal);
                    if (journal.journalID != 0)
                        JournalsDataBase.DeleteJournal(journal);
                },
                (journal) => journal != null);

            SaveAllCommand = new Command(() => JournalsDataBase.SaveAll(Journals));

            RefreshCommand =
                new Command(async () =>
                {
                    IsRefreshing = true;
                    LoadData();
                    // Simulates a longer operation
                    await Task.Delay(2000);
                    IsRefreshing = false;
                }
            );
        }
    }
}
