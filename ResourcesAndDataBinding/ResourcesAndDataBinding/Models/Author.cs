using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ResourcesAndDataBinding.Models
{
    public class Author : INotifyPropertyChanged
    {
        public int authorID { get; set; }

        private string _name;

        [MaxLength(50)]
        [NotNull]
        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private int _age;
        public int age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName
                                        = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
