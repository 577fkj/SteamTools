using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

// ReSharper disable once CheckNamespace
namespace System.Application.UI.ViewModels
{
    public partial class ItemViewModel : ViewModelBase
    {
        #region IsSelected 変更通知

        private bool _IsSelected;

        public virtual bool IsSelected
        {
            get => _IsSelected;
            set => this.RaiseAndSetIfChanged(ref _IsSelected, value);
        }

        #endregion

        #region IsShowTab 変更通知

        private bool _IsShowTab = true;

        public virtual bool IsShowTab
        {
            get => _IsShowTab;
            set => this.RaiseAndSetIfChanged(ref _IsShowTab, value);
        }

        #endregion
    }
}
