namespace MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    ///     Сервис навигации
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        ///     Показать окно
        /// </summary>
        /// <typeparam name="T">Тип окна</typeparam>
        void ShowWindow<T>() where T : Window;

        /// <summary>
        ///     Открыть редактор
        /// </summary>
        /// <typeparam name="TEditorControl">Тип редактора</typeparam>
        /// <param name="entityId">Идентификатор сущности</param>
        void OpenEditor<TEditorControl>(Guid entityId) where TEditorControl : UserControl;
    }
}