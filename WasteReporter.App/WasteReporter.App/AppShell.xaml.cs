using System;
using System.Collections.Generic;
using WasteReporter.App.ViewModels;
using WasteReporter.App.Views;
using Xamarin.Forms;

namespace WasteReporter.App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
