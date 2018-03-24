using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniHub.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    partial class Main : MasterDetailPage
    {
        internal Main()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}