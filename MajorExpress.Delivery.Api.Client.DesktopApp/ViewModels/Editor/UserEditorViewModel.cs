namespace MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor
{
    using System;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces;
    using MajorExpress.Delivery.Api.Client.Interfaces;
    using MajorExpress.Delivery.Api.Client.Models;

    /// <summary>
    ///     Модель представления <see cref="UserEditor"/>
    /// </summary>
    public class UserEditorViewModel : EntityEditorViewModel
    {
        private readonly IDeliveryApiClient _apiClient;
        private readonly INotificationService _notificationService;
        private User _model;

        public UserEditorViewModel()
        {
            
        }

        public UserEditorViewModel(
            IDeliveryApiClient apiClient,
            INotificationService notificationService) : this()
        {
            _apiClient = apiClient;
            _notificationService = notificationService;
        }

        public User Model
        {
            get => _model;
            set => this.Set(ref _model, value);
        }

        public override string EditorTitle => "Редактор пользователя";

        protected override bool IsNewRecord => this.Model == null || this.Model.Id == default;

        protected override bool CanUpdate => true;

        public override async Task CreateAsync()
        {
            var response = await _apiClient.CreateUserAsync(this.Model);
            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Создание пользователя");
                return;
            }

            this.Model = response.Data;
        }

        public override async Task UpdateAsync()
        {
            var response = await _apiClient.UpdateUserAsync(this.Model);
            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Редактирование пользователя");
                return;
            }

            this.Model = response.Data;
        }

        public override async Task LoadAsync(Guid entityId)
        {
            if (entityId != default)
            {
                var response = await _apiClient.GetUserAsync(entityId);
                if (!response.IsSuccess)
                {
                    _notificationService.Alert(response.ErrorMessage, "Загрузка пользователя");
                    return;
                }
                this.Model = response.Data;
            }

            this.Model ??= new User();
        }
    }
}
