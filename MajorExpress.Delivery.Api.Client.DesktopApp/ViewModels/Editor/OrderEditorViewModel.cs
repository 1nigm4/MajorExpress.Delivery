namespace MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Commands.Base;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces;
    using MajorExpress.Delivery.Api.Client.Interfaces;
    using MajorExpress.Delivery.Api.Client.Models;

    /// <summary>
    ///     Модель представления <see cref="OrderEditor"/>
    /// </summary>
    public class OrderEditorViewModel : EntityEditorViewModel
    {
        private readonly IDeliveryApiClient _deliveryApiClient;
        private readonly INotificationService _notificationService;
        private Order _model;

        public OrderEditorViewModel()
        {
            
        }

        public OrderEditorViewModel(
            IDeliveryApiClient deliveryApiClient,
            INotificationService notificationService) : this()
        {
            _deliveryApiClient = deliveryApiClient;
            _notificationService = notificationService;

            this.ExecuteOrderCommand = new RelayCommand(this.ExecuteOrder, (o) => !this.IsNewRecord && this.Model.Status == 1);
            this.CompleteOrderCommand = new RelayCommand(this.CompleteOrder, (o) => !this.IsNewRecord && this.Model.Status == 2);
            this.CancelOrderCommand = new RelayCommand(this.CancelOrder, (o) => !this.IsNewRecord && this.Model?.Status < 3);
        }

        /// <summary>
        ///     Команда "Передать на выполнение"
        /// </summary>
        public ICommand ExecuteOrderCommand { get; }

        /// <summary>
        ///     Команда "Выполнить"
        /// </summary>
        public ICommand CompleteOrderCommand { get; }

        /// <summary>
        ///     Команда "Отменить"
        /// </summary>
        public ICommand CancelOrderCommand { get; }

        public Order Model
        {
            get => _model;
            set => this.Set(ref _model, value);
        }

        public override string EditorTitle => "Редактор заявки";

        protected override bool IsNewRecord => this.Model == null || this.Model.Id == default;

        protected override bool CanUpdate => this.Model != null && this.Model.Status == 1;

        public override async Task CreateAsync()
        {
            var response = await _deliveryApiClient.CreateOrderAsync(this.Model);
            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Создание заявки");
                return;
            }
                
            this.Model = response.Data;
        }

        public override async Task UpdateAsync()
        {
            var response = await _deliveryApiClient.UpdateOrderAsync(this.Model);
            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Редактирование заявки");
                return;
            }

            this.Model = response.Data;
        }

        public override async Task LoadAsync(Guid entityId)
        {
            if (entityId != default)
            {
                var response = await _deliveryApiClient.GetOrderAsync(entityId);
                if (!response.IsSuccess)
                {
                    _notificationService.Alert(response.ErrorMessage, "Загрузка заявки");
                    return;
                }

                this.Model = response.Data;
            }

            this.Model ??= new Order
            {
                Client = new Client(),
                Cargo = new Cargo(),
                Courier = new Courier(),
                CreatedAt = DateTime.Now,
                Status = 1,
            };
        }

        private async void CancelOrder(object? obj)
        {
            if (string.IsNullOrWhiteSpace(this.Model.CancelComment))
            {
                _notificationService.Alert("Необходимо указать причину отмены", "Отменить заявку");
                return;
            }

            var response = await _deliveryApiClient.CancelOrderAsync(this.Model);
            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Отмена заявки");
                return;
            }

            this.Model = response.Data;
        }

        private async void CompleteOrder(object? obj)
        {
            var response = await _deliveryApiClient.CompleteOrderAsync(this.Model);
            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Выполнить заявку");
                return;
            }

            this.Model = response.Data;
        }

        private async void ExecuteOrder(object? obj)
        {
            if (this.Model.Courier == null)
            {
                _notificationService.Alert("Необходимо указать курьера", "Передать на выполнение");
                return;
            }

            var response = await _deliveryApiClient.ExecuteOrderAsync(this.Model);
            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Передать на выполнение");
                return;
            }

            this.Model = response.Data;
        }
    }
}
