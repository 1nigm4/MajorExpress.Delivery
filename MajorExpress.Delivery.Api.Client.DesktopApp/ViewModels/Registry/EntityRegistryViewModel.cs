namespace MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Registry
{
    using System.Windows.Input;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Commands.Base;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Registry;
    using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Base;

    /// <summary>
    ///     Модель представления реестра сущности <see cref="EntityRegistry"/>
    /// </summary>
    public class EntityRegistryViewModel : ViewModel
    {
        private int _pageIndex = 1;
        private int _pageSize = 25;
        private int _totalCount;
        private object _selectionEntity;

        public EntityRegistryViewModel()
        {
            this.AddCommand = new RelayCommand(this.Add);
            this.RefreshCommand = new RelayCommand(this.RefreshAsync);
            this.EditCommand = new RelayCommand(this.Edit, (o) => this.SelectionEntity != null);
            this.RemoveCommand = new RelayCommand(this.Remove, this.CanRemove);
        }

        /// <summary>
        ///     Заголовок окна реестра
        /// </summary>
        public virtual string RegistryTitle { get; } = "Реестр";

        /// <summary>
        ///     Команда "Добавить"
        /// </summary>
        public ICommand AddCommand { get; protected set; }

        /// <summary>
        ///     Команда "Обновить"
        /// </summary>
        public ICommand RefreshCommand { get; protected set; }

        /// <summary>
        ///     Команда "Редактировать"
        /// </summary>
        public ICommand EditCommand { get; protected set; }

        /// <summary>
        ///     Команда "Удалить"
        /// </summary>
        public ICommand RemoveCommand { get; protected set; }

        /// <summary>
        ///     Страница
        /// </summary>
        public int PageIndex
        {
            get => _pageIndex;
            set
            {
                if (this.Set(ref _pageIndex, value))
                {
                    this.RefreshCommand.Execute(null);
                }
            }
        }

        /// <summary>
        ///     Размер страницы
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (this.Set(ref _pageSize, value))
                {
                    this.RefreshCommand.Execute(null);
                }
            }
        }

        /// <summary>
        ///     Общее количество
        /// </summary>
        public int TotalCount
        {
            get => _totalCount;
            set => this.Set(ref _totalCount, value);
        }

        /// <summary>
        ///     Выбранная запись (предварительно)
        /// </summary>
        public object SelectionEntity
        {
            get => _selectionEntity;
            set => this.Set(ref _selectionEntity, value);
        }

        /// <summary>
        ///     Выбранная запись (окончательно)
        /// </summary>
        public object SelectedEntity { get; set; }

        /// <summary>
        ///     Отображаемые размеры страниц
        /// </summary>
        public int[] DisplayQuantityValues => [25, 50, 75, 100];

        /// <summary>
        ///     Загрузить реестр
        /// </summary>
        public virtual Task LoadStoreAsync() => throw new NotImplementedException();

        /// <summary>
        ///     Обработчик команды <see cref="AddCommand"/>
        /// </summary>
        protected virtual void Add(object? obj) => throw new NotImplementedException();

        /// <summary>
        ///     Обработчик команды <see cref="EditCommand"/>
        /// </summary>
        protected virtual void Edit(object? obj) => throw new NotImplementedException();

        /// <summary>
        ///     Обработчик команды <see cref="RemoveCommand"/>
        /// </summary>
        protected virtual void Remove(object? obj) => throw new NotImplementedException();

        /// <summary>
        ///     Обработчик команды <see cref="RefreshCommand"/>
        /// </summary>
        private async void RefreshAsync(object? obj) => await this.LoadStoreAsync();

        /// <summary>
        ///     Условие команды <see cref="RemoveCommand"/>
        /// </summary>
        protected virtual bool CanRemove(object? arg) => false;
    }
}
