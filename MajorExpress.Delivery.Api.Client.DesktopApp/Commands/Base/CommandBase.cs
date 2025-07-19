namespace MajorExpress.Delivery.Api.Client.DesktopApp.Commands.Base
{
    using System.Windows.Input;

    /// <summary>
    ///     Базовая команда
    /// </summary>
    internal abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        ///     Можно ли вызвать команду
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        public abstract bool CanExecute(object? parameter);

        /// <summary>
        ///     Выполнить команду
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        public abstract void Execute(object? parameter);
    }
}
