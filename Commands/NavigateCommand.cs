using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Services;
using Competitions.Stores;
using Competitions.ViewModels;

namespace Competitions.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private readonly Pages page;

        public NavigateCommand(NavigationService navigationService, Pages page)
        {
            _navigationService = navigationService;
            this.page = page;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(page); // TODO:
        }
    }
}
