using System.ComponentModel;
using WasteReporter.App.ViewModels;
using Xamarin.Forms;

namespace WasteReporter.App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}