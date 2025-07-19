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
    ///     Модель представления <see cref="UserRegistry"/>
    /// </summary>
    public class UserRegistryViewModel : EntityRegistryViewModel
    {
        private readonly IDeliveryApiClient _apiClient;
        private readonly INavigationService _navigationService;
        private readonly INotificationService _notificationService;

        private ObservableCollection<User> _users;

        public UserRegistryViewModel()
        {

        }

        public UserRegistryViewModel(
            IDeliveryApiClient deliveryApiClient,
            INavigationService navigationService,
            INotificationService notificationService)
        {
            _apiClient = deliveryApiClient;
            _navigationService = navigationService;
            _notificationService = notificationService;
        }

        public ObservableCollection<User> Users
        {
            get => _users;
            set => this.Set(ref _users, value);
        }

        public override string RegistryTitle => "Реестр пользователей";

        public override async Task LoadStoreAsync()
        {
            var response = await _apiClient.ListUsersAsync(new ListRequest
            {
                PageIndex = this.PageIndex,
                PageSize = this.PageSize,
            });

            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Загрузка реестра пользователей");
                return;
            }

            this.Users = new ObservableCollection<User>(response.Data.Items);
            this.TotalCount = response.Data.TotalCount;
            this.PageIndex = response.Data.PageIndex;
            this.PageSize = response.Data.PageSize;
        }

        protected override void Add(object? obj)
        {
            _navigationService.OpenEditor<UserEditor>(default);
        }

        protected override void Edit(object? obj)
        {
            if (obj is not User user) return;
            _navigationService.OpenEditor<UserEditor>(user.Id);
        }
    }
}
