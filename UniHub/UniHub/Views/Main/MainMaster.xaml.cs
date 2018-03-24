using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniHub.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    partial class MainMaster : ContentPage
    {
        public ListView ListView;

        internal MainMaster()
        {
            InitializeComponent();

            BindingContext = new MainMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainMasterViewModel : INotifyPropertyChanged
        {
            ObservableCollection<MainMenuItem> MenuItems { get; set; }

            internal MainMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainMenuItem>(new[]
                {
                    new MainMenuItem { Id = 0, Title = "Page 1" },
                    new MainMenuItem { Id = 1, Title = "Page 2" },
                    new MainMenuItem { Id = 2, Title = "Page 3" },
                    new MainMenuItem { Id = 3, Title = "Page 4" },
                    new MainMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}