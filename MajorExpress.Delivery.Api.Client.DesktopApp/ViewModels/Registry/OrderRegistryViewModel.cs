namespace MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Registry
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Registry;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces;
    using MajorExpress.Delivery.Api.Client.Interfaces;
    using MajorExpress.Delivery.Api.Client.Models;
    using MajorExpress.Delivery.Api.Client.Requests;

    /// <summary>
    ///     Модель представления <see cref="OrderRegistry"/>
    /// </summary>
    public class OrderRegistryViewModel : EntityRegistryViewModel
    {
        private readonly IDeliveryApiClient _apiClient;
        private readonly INavigationService _navigationService;
        private readonly INotificationService _notificationService;

        private ObservableCollection<Order> _orders;
        private string _filter;

        public OrderRegistryViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                this.FillTemplateData();
            }
        }

        public OrderRegistryViewModel(
            IDeliveryApiClient apiClient,
            INavigationService navigationService,
            INotificationService notificationService) : this()
        {
            _apiClient = apiClient;
            _navigationService = navigationService;
            _notificationService = notificationService;
        }

        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set => this.Set(ref _orders, value);
        }

        public string Filter
        {
            get => _filter;
            set
            {
                if (this.Set(ref _filter, value))
                {
                    this.RefreshCommand.Execute(this);
                }
            }
        }

        public override string RegistryTitle => "Реестр заявок";

        protected override bool CanRemove(object? arg) => this.SelectionEntity != null;

        public override async Task LoadStoreAsync()
        {
            var response = await _apiClient.ListOrdersAsync(new ListRequest
            {
                PageIndex = this.PageIndex,
                PageSize = this.PageSize,
                Filter = this.Filter,
            });

            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Загрузка реестра заявок");
                return;
            }

            this.Orders = new ObservableCollection<Order>(response.Data.Items);
            this.TotalCount = response.Data.TotalCount;
            this.PageIndex = response.Data.PageIndex;
            this.PageSize = response.Data.PageSize;
        }

        protected override void Add(object? obj)
        {
            _navigationService.OpenEditor<OrderEditor>(default);
        }

        protected override void Edit(object? obj)
        {
            if (obj is not Order order) return;
            _navigationService.OpenEditor<OrderEditor>(order.Id);
        }

        protected override async void Remove(object? obj)
        {
            if (obj is not Order order) return;
            var response = await _apiClient.RemoveOrderAsync(order.Id);
            if (!response.IsSuccess)
            {
                _notificationService.Alert(response.ErrorMessage, "Удаление заявки");
                return;
            }

            this.Orders.Remove(order);
            this.TotalCount--;
        }

        private void FillTemplateData()
        {
            var orders = Enumerable.Range(1, 4).Select(index => new Order
            {
                Client = new Client
                {
                    User = new User
                    {
                        FirstName = $"Клиент{index}",
                        LastName = $"Клиентов{index}",
                        Patronymic = $"Клиентович{index}",
                        PhoneNumber = string.Format("({0}{0}{0}) {0}{0}{0} {0}{0}-{0}{0}", index),
                    },
                },
                Cargo = new Cargo
                {
                    Description = $"Товар{index}",
                    Size = (ushort)(index),
                    Weight = (ushort)(index),
                },
                Courier = new Courier
                {
                    User = new User
                    {
                        FirstName = $"Курьер{index}",
                        LastName = $"Курьеров{index}",
                        Patronymic = $"Курьерович{index}",
                        PhoneNumber = string.Format("({0}{0}{0}) {0}{0}{0} {0}{0}-{0}{0}", index + 1),
                    },
                },
                Status = (byte)index,
                PickupAddress = $"Заберут тут {index}",
                DeliveryAddress = $"Доставят сюда {index}",
                CreatedAt = DateTime.Now.AddDays(-index * 8),
                PickupTime = DateTime.Now.AddDays(-index),
                CancelComment = $"Тестовая причина {index}",
            }).ToList();

            _orders = new ObservableCollection<Order>(orders);
        }
    }
}
