using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace UserControlTest.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        protected string InstanceName;

        public ViewModelBase()
        {
            InstanceName = $"{GetType().Name}-{Guid.NewGuid().ToString().Substring(32, 4)}";
            Debug.WriteLine($"ViewModelBase.Ctr [{InstanceName}]");
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
