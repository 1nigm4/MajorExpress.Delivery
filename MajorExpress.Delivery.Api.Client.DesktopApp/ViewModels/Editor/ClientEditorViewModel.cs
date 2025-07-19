namespace MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor
{
    using System;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces;
    using MajorExpress.Delivery.Api.Client.Interfaces;
    using MajorExpress.Delivery.Api.Client.Models;

    /// <summary>
    ///     Модель представления <see cref="ClientEditor"/>
    /// </summary>
    public class ClientEditorViewModel : EntityEditorViewModel
    {
        private readonly IDeliveryApiClient _apiClient;
        private readonly INotificationService _notificationService;
        private Client _model;

        public ClientEditorViewModel()
        {
            
        }

        public ClientEditorViewModel(
            IDeliveryApiClient apiClient,
            INotificationService notificationService) : this()
        {
            _apiClient = apiClient;
            _notificationService = notificationService;
        }

        public Client Model
        {
            get => _model;
            set => this.Set(ref _model, value);
        }

        public override string EditorTitle => "Редактор клиента";

        protected override bool IsNewRecord => this.Model == null || this.Model.Id == default;

        public override async Task CreateAsync()
        {
            var response = await _apiClient.CreateClientAsync(this.Model);
            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Создание клиента");
                return;
            }

            this.Model = response.Data;
        }

        public override async Task LoadAsync(Guid entityId)
        {
            if (entityId != default)
            {
                var response = await _apiClient.GetClientAsync(entityId);
                if (!response.IsSuccess)
                {
                    _notificationService.Alert(response.ErrorMessage, "Загрузка клиента");
                    return;
                }

                this.Model = response.Data;
            }

            this.Model ??= new Client();
        }
    }
}
