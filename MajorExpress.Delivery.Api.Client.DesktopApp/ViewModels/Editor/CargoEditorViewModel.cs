namespace MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor
{
    using System;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces;
    using MajorExpress.Delivery.Api.Client.Interfaces;
    using MajorExpress.Delivery.Api.Client.Models;

    /// <summary>
    ///     Модель представления <see cref="CargoEditor"/>
    /// </summary>
    public class CargoEditorViewModel : EntityEditorViewModel
    {
        private readonly IDeliveryApiClient _client;
        private readonly INotificationService _notificationService;
        private Cargo _model;

        public CargoEditorViewModel()
        {
            
        }

        public CargoEditorViewModel(
            IDeliveryApiClient client,
            INotificationService notificationService) : this()
        {
            _client = client;
            _notificationService = notificationService;
        }

        public Cargo Model
        {
            get => _model;
            set => this.Set(ref _model, value);
        }

        public override string EditorTitle => "Редактор груза";

        protected override bool IsNewRecord => this.Model == null || this.Model.Id == default;

        public override async Task CreateAsync()
        {
            var response = await _client.CreateCargoAsync(this.Model);
            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Сохранение груза");
                return;
            }

            this.Model = response.Data;
        }

        public override async Task LoadAsync(Guid entityId)
        {
            if (entityId != default)
            {
                var response = await _client.GetCargoAsync(entityId);
                if (!response.IsSuccess)
                {
                    _notificationService.Alert(response.ErrorMessage, "Загрузка груз");
                    return;
                }

                this.Model = response.Data;
            }

            this.Model ??= new Cargo();
        }
    }
}
