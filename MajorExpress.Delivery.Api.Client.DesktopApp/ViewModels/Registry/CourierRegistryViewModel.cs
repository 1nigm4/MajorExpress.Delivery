namespace MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Registry
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Registry;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces;
    using MajorExpress.Delivery.Api.Client.Interfaces;
    using MajorExpress.Delivery.Api.Client.Models;
    using MajorExpress.Delivery.Api.Client.Requests;

    /// <summary>
    ///     Модель представления <see cref="CourierRegistry"/>
    /// </summary>
    public class CourierRegistryViewModel : EntityRegistryViewModel
    {
        private readonly IDeliveryApiClient _apiClient;
        private readonly INavigationService _navigationService;
        private readonly INotificationService _notificationService;
        private ObservableCollection<Courier> _couriers;

        public CourierRegistryViewModel()
        {

        }

        public CourierRegistryViewModel(
            IDeliveryApiClient deliveryApiClient,
            INavigationService navigationService,
            INotificationService notificationService) : this()
        {
            _apiClient = deliveryApiClient;
            _navigationService = navigationService;
            _notificationService = notificationService;
        }

        public ObservableCollection<Courier> Couriers
        {
            get => _couriers;
            set => this.Set(ref _couriers, value);
        }

        public override string RegistryTitle => "Реестр исполнителей";

        public override async Task LoadStoreAsync()
        {
            var response = await _apiClient.ListCouriersAsync(new ListRequest
            {
                PageIndex = this.PageIndex,
                PageSize = this.PageSize,
            });

            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Загрузка реестра исполнителей");
                return;
            }

            this.Couriers = new ObservableCollection<Courier>(response.Data.Items);
            this.TotalCount = response.Data.TotalCount;
            this.PageIndex = response.Data.PageIndex;
            this.PageSize = response.Data.PageSize;
        }

        protected override void Add(object? obj)
        {
            _navigationService.OpenEditor<CourierEditor>(default);
        }

        protected override void Edit(object? obj)
        {
            if (obj is not Courier courier) return;
            _navigationService.OpenEditor<CourierEditor>(courier.Id);
        }
    }
}
