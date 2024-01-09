using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace ResourcesAndDataBinding.Models
{
    [Table("Journal")]
    public class Journal : INotifyPropertyChanged
    {
        [PrimaryKey]
        [AutoIncrement]
        public int journalID { get; set; }

        private int _pages;
        public int pages
        {
            get
            {
                return _pages;
            }

            set
            {
                _pages = value;
                OnPropertyChanged();
            }
        }

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

        private bool _isFamilyMember;
        public bool IsFamilyMember
        {
            get
            {
                return _isFamilyMember;
            }

            set
            {
                _isFamilyMember = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}