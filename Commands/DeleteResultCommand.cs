using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Competitions.Models;
using Competitions.Services;
using Competitions.ViewModels;
using Competitions.Views;

namespace Competitions.Commands
{
    public class DeleteResultCommand : CommandBase
    {
        private readonly Athlete _athlete;
        private readonly Result _result;
        private readonly NavigationService? _deleteResultNavigationService;
        public override void Execute(object? parameter)
        {
            try
            {
                _athlete.DeleteResult(_result);
                _deleteResultNavigationService?.Navigate(Pages.BestResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        public DeleteResultCommand(Athlete athlete, Result result, NavigationService? deleteResultNavigationService)
        {
            _athlete = athlete;
            _result = result;
            _deleteResultNavigationService = deleteResultNavigationService;
        }
    }
}
