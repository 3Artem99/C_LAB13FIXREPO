using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResourcesAndDataBinding.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JournalsListView : ContentPage
    {
        private ObservableCollection<Journal> Journal { get; set; }
        public JournalsListView()
        {
            InitializeComponent();
            Journal = new ObservableCollection<Journal>();
            Journal j1 = new Journal
            {
                journalID = 01,
                pages = 0111,
                name = "aaaa"
            };
            Journal j2 = new Journal
            {
                journalID = 02,
                pages = 0222,
                name = "bbbb"
            };
            Journal j3 = new Journal
            {
                journalID = 03,
                pages = 0333,
                name = "cccc"
            };

            Journal.Add(j1);
            Journal.Add(j2);
            Journal.Add(j3);
            BindingContext = Journal;
        }

        private void JournalList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var journal = e.SelectedItem as Journal;
            if (journal != null)
            {
                DisplayAlert("Edit", "Here we can edit selected element", "Ok");
            }
        }
    }
}