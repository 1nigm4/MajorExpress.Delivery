namespace MajorExpress.Delivery.Api.Client.DesktopApp
{
    using System.Windows;
    using System.Windows.Markup;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Components.Registry;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Impl;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces;
    using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor;
    using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Registry;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Views.Windows;
    using MajorExpress.Delivery.Api.Client.Extensions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public partial class App : Application
    {
        private static IHost _host;
        public static IServiceProvider ServiceProvider => _host.Services;

        public App()
        {
            var builder = Host.CreateDefaultBuilder();
            builder.ConfigureServices(this.Initialize);

            _host = builder.Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var navigation = _host.Services.GetRequiredService<INavigationService>();
            navigation.ShowWindow<MainWindow>();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }

        private void Initialize(HostBuilderContext context, IServiceCollection services)
        {
            this.RegisterWindows(services);
            this.RegisterServices(services);
            this.RegisterViewModels(services);
            this.RegisterEditors(services);
            this.RegisterRegistries(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddDeliveryClient(config =>
            {
                config.BaseUrl = "http://localhost:8080";
            });

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<INotificationService, NotificationService>();
        }

        private void RegisterEditors(IServiceCollection services)
        {
            services.AddTransient<OrderEditor>();
            services.AddTransient<UserEditor>();
            services.AddTransient<CargoEditor>();
            services.AddTransient<ClientEditor>();
            services.AddTransient<CourierEditor>();
        }

        private void RegisterRegistries(IServiceCollection services)
        {
            services.AddTransient<OrderRegistry>();
            services.AddTransient<UserRegistry>();
            services.AddTransient<ClientRegistry>();
            services.AddTransient<CourierRegistry>();
            services.AddTransient<CargoRegistry>();
        }

        private void RegisterViewModels(IServiceCollection services)
        {
            services.AddTransient<OrderRegistryViewModel>();
            services.AddTransient<OrderEditorViewModel>();
            services.AddTransient<UserEditorViewModel>();
            services.AddTransient<UserRegistryViewModel>();
            services.AddTransient<CargoEditorViewModel>();
            services.AddTransient<CargoRegistryViewModel>();
            services.AddTransient<ClientRegistryViewModel>();
            services.AddTransient<ClientEditorViewModel>();
            services.AddTransient<CourierRegistryViewModel>();
            services.AddTransient<CourierEditorViewModel>();
        }

        private void RegisterWindows(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddTransient<EditorWindow>();
            services.AddTransient<RegistryWindow>();
        }
    }

    public class Service : MarkupExtension
    {
        public Type Type { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return App.ServiceProvider.GetRequiredService(Type);
        }
    }
}
