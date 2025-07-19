namespace MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Registry
{
    using System.Collections.ObjectModel;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Registry;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces;
    using MajorExpress.Delivery.Api.Client.Interfaces;
    using MajorExpress.Delivery.Api.Client.Models;
    using MajorExpress.Delivery.Api.Client.Requests;

    /// <summary>
    ///     Модель представления <see cref="CargoRegistry"/>
    /// </summary>
    public class CargoRegistryViewModel : EntityRegistryViewModel
    {
        private readonly IDeliveryApiClient _deliveryApiClient;
        private readonly INavigationService _navigationService;
        private readonly INotificationService _notificationService;
        private ObservableCollection<Cargo> _cargos;

        public CargoRegistryViewModel()
        {
            
        }

        public CargoRegistryViewModel(
            IDeliveryApiClient deliveryApiClient,
            INavigationService navigationService,
            INotificationService notificationService) : this()
        {
            _deliveryApiClient = deliveryApiClient;
            _navigationService = navigationService;
            _notificationService = notificationService;
        }

        public ObservableCollection<Cargo> Cargos
        {
            get => _cargos;
            set => this.Set(ref _cargos, value);
        }

        public override string RegistryTitle => "Реестр грузов";

        public override async Task LoadStoreAsync()
        {
            var response = await _deliveryApiClient.ListCargosAsync(new ListRequest
            {
                PageIndex = this.PageIndex,
                PageSize = this.PageSize,
            });

            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Загрузка реестра грузов");
                return;
            }

            this.Cargos = new ObservableCollection<Cargo>(response.Data.Items);
            this.TotalCount = response.Data.TotalCount;
            this.PageIndex = response.Data.PageIndex;
            this.PageSize = response.Data.PageSize;
        }

        protected override void Add(object? obj)
        {
            _navigationService.OpenEditor<CargoEditor>(default);
        }

        protected override void Edit(object? obj)
        {
            if (obj is not Cargo cargo) return;
            _navigationService.OpenEditor<CargoEditor>(cargo.Id);
        }
    }
}
