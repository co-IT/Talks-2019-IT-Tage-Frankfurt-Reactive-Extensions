using System;
using System.Net.NetworkInformation;
using System.Reactive.Linq;

namespace SmartGateIn.Daemon
{
    public class ConnectivityDaemon
    {
        public IObservable<bool> ShouldLockClient()
        {
            return Observable
                .Return(!NetworkInterface.GetIsNetworkAvailable())
                .Concat(Observable
                    .FromEventPattern<NetworkAvailabilityChangedEventHandler, NetworkAvailabilityEventArgs>(
                        add => NetworkChange.NetworkAvailabilityChanged += add,
                        remove => NetworkChange.NetworkAvailabilityChanged -= remove
                    )
                    .Select(change => !change.EventArgs.IsAvailable));
        }
    }
}