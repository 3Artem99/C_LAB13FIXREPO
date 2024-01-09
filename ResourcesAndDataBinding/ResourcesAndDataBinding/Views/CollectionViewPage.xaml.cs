using ResourcesAndDataBinding.Models;
using ResourcesAndDataBinding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResourcesAndDataBinding.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionViewPage : ContentPage
    {

        private JournalViewModel ViewModel { get; set; }
        public CollectionViewPage()
        {
            InitializeComponent();
            ViewModel = new JournalViewModel();
            BindingContext = ViewModel;
        }

        private void JournalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // In case of single selection
            var selectedPerson = this.JournalList.SelectedItem as Journal;

            // In case of multi-selection:
            var singlePerson = e.CurrentSelection.FirstOrDefault() as Journal;

            var selectedObjects = e.CurrentSelection.Cast<Journal>();
            foreach (var person in selectedObjects)
            {
                // Handle your object properties here...
            }
        }
    }
}