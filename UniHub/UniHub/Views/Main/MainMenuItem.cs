using System;
using UniHub.Views.Main.Home;

namespace UniHub.Views.Main
{
    class MainMenuItem
    {
        internal MainMenuItem()
        {
            TargetType = typeof(HomeView);
        }
        internal int Id { get; set; }
        internal string Title { get; set; }

        internal Type TargetType { get; set; }
    }
}