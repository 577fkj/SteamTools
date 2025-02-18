using System;
using System.Application.Services;
using System.Application.UI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using VM = System.Application.UI.ViewModels.ArchiSteamFarmPlusPageViewModel;
using Interface = System.Application.UI.Views.IArchiSteamFarmPlusPage;

namespace System.Application.UI.Views.Native
{
    public partial class ArchiSteamFarmPlusPage : BaseContentPage<VM>, Interface
    {
        public IReadOnlyDictionary<VM.ActionItem, ToolbarItem> Actions { get; }

        public ArchiSteamFarmPlusPage()
        {
            ViewModel = IViewModelManager.Instance.GetMainPageViewModel<VM>();

            Actions = Interface.InitToolbarItems(this);
        }
    }
}
