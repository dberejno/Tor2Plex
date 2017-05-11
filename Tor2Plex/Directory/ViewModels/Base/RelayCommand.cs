using System;
using System.Windows.Input;

namespace Tor2Plex.Directory.ViewModels
{
    /// <summary>
    /// A basic command that runs an Action
    /// </summary>
    class RelayCommand : ICommand
    {
        #region Private Members
        private Action _action;
        #endregion

        #region Public Events
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor
        public RelayCommand(Action action)
        {
            _action = action;
        }
        #endregion

        #region Command Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
        #endregion
    }
}
