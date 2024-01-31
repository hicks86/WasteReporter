using System;
using System.Collections.Generic;
using System.ComponentModel;
using WasteReporter.App.Models;
using WasteReporter.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WasteReporter.App.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}