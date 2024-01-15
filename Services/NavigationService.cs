using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Stores;
using Competitions.ViewModels;

namespace Competitions.Services
{
    public class NavigationService
    {
        private readonly NavigationStore? _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigationService(NavigationStore? navigationStore, Func<ViewModelBase> createViewModel) // маленькая фабрика
        {
            this._navigationStore = navigationStore;
            this._createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
