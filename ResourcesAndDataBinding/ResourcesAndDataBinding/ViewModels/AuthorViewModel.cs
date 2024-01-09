using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ResourcesAndDataBinding.ViewModels
{
    public class AuthorViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Author> People { get; set; }
        private Author _selectedAuthor;
        public Author SelectedAuthor
        {
            get
            {
                return _selectedAuthor;
            }
            set
            {
                _selectedAuthor = value;
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
        public ICommand RefreshCommand { get; set; }
        public ICommand AddAuthorCommand { get; set; }
        public ICommand DeleteAuthorCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void LoadSampleData()
        {
            People = new ObservableCollection<Author>();
            // sample data
            Author a1 =
            new Author
            {
                authorID = 1,
                name = "PUSHKIN",
                age = 1111,
            };
            Author a2 =
            new Author
            {
                authorID = 2,
                name = "ESENIN",
                age = 2222,
            };
            Author a3 =
            new Author
            {
                authorID = 3,
                name = "fghjkl",
                age = 3333,
            };
            People.Add(a1);
            People.Add(a2);
            People.Add(a3);
        }

        public AuthorViewModel()
        {
            LoadSampleData();

            Random r = new Random();
            AddAuthorCommand = new Command(() => People.Add(new Author()
            {
                authorID = 4,
                name = "uytfghjk",
                age = 4444,
            }));

            DeleteAuthorCommand = new Command<Author>((author) => People.Remove(author));

            RefreshCommand = new Command(async () =>
            {
                IsRefreshing = true;
                LoadSampleData();
                // Simulates a longer operation
                await Task.Delay(2000);
                IsRefreshing = false;
            });
        }

    }
}
