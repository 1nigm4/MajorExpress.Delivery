namespace MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor
{
    using System.Windows.Input;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Commands.Base;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor;
    using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Base;

    /// <summary>
    ///     Модель представления редактора сущности <see cref="EntityEditor"/>
    /// </summary>
    public class EntityEditorViewModel : ViewModel
    {
        public EntityEditorViewModel()
        {
            this.SaveOrderCommand = new RelayCommand(this.SaveAsync, (o) => this.IsNewRecord || this.CanUpdate);
        }

        /// <summary>
        ///     Заголовок окна редактора
        /// </summary>
        public virtual string EditorTitle { get; } = "Редактор";

        /// <summary>
        ///     Является новой записью
        /// </summary>
        protected virtual bool IsNewRecord
        {
            get => throw new NotImplementedException();
        }

        protected virtual bool CanUpdate => false;

        /// <summary>
        ///     Команда сохранить запись
        /// </summary>
        public ICommand SaveOrderCommand { get; private set; }

        /// <summary>
        ///     Создать запись
        /// </summary>
        public virtual Task CreateAsync() => throw new NotImplementedException();

        /// <summary>
        ///     Обновить запись
        /// </summary>
        public virtual Task UpdateAsync() => throw new NotImplementedException();

        /// <summary>
        ///     Загрузить запись
        /// </summary>
        /// <param name="entityId">Идентификатор сущности</param>
        public virtual Task LoadAsync(Guid entityId) => throw new NotImplementedException();

        /// <summary>
        ///     Обработчик команды <see cref="SaveOrderCommand"/>
        /// </summary>
        /// <param name="obj"></param>
        protected virtual async void SaveAsync(object? obj)
        {
            if (this.IsNewRecord)
            {
                await this.CreateAsync();
            }
            else if (this.CanUpdate)
            {
                await this.UpdateAsync();
            }
        }
    }
}
