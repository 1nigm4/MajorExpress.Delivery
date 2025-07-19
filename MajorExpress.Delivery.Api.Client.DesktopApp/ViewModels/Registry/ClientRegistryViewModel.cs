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
    ///     Модель представления <see cref="ClientRegistry"/>
    /// </summary>
    public class ClientRegistryViewModel : EntityRegistryViewModel
    {
        private readonly IDeliveryApiClient _apiClient;
        private readonly INavigationService _navigationService;
        private readonly INotificationService _notificationService;
        private ObservableCollection<Client> _clients;

        public ClientRegistryViewModel()
        {

        }

        public ClientRegistryViewModel(
            IDeliveryApiClient deliveryApiClient,
            INavigationService navigationService,
            INotificationService notificationService) : this()
        {
            _apiClient = deliveryApiClient;
            _navigationService = navigationService;
            _notificationService = notificationService;
        }

        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => this.Set(ref _clients, value);
        }

        public override string RegistryTitle => "Реестр клиентов";

        public override async Task LoadStoreAsync()
        {
            var response = await _apiClient.ListClientsAsync(new ListRequest
            {
                PageIndex = this.PageIndex,
                PageSize = this.PageSize,
            });

            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Загрузка реестра клиентов");
                return;
            }

            this.Clients = new ObservableCollection<Client>(response.Data.Items);
            this.TotalCount = response.Data.TotalCount;
            this.PageIndex = response.Data.PageIndex;
            this.PageSize = response.Data.PageSize;
        }

        protected override void Add(object? obj)
        {
            _navigationService.OpenEditor<ClientEditor>(default);
        }

        protected override void Edit(object? obj)
        {
            if (obj is not Client client) return;
            _navigationService.OpenEditor<ClientEditor>(client.Id);
        }
    }
}
