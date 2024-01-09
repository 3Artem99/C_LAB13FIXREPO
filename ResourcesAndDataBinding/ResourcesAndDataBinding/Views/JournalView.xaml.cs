using ResourcesAndDataBinding.Models;
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
    public partial class JournalView : ContentPage
    {
        private Journal NewJournal { get; set; }
        public JournalView()
        {
            InitializeComponent();
            NewJournal = new Journal
            {
                journalID = 023,
                pages = 02333,
                name = "cbccc"
            };

            BindingContext = NewJournal;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Journal saved", $"{NewJournal.journalID} " +
                $"{Environment.NewLine} {NewJournal.pages} " +
                $"{Environment.NewLine} {NewJournal.name}", "Ok");
        }
    }
}