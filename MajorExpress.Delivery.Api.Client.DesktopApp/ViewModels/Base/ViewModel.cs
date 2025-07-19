namespace MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Base
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     Базовая модель представления
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? PropertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            this.OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
