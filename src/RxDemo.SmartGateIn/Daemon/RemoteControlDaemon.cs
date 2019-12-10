using System;
using System.Reactive.Linq;
using SmartGateIn.Properties;
using SmartGateIn.SapWebservices;

namespace SmartGateIn.Daemon
{
    public class RemoteControlDaemon
    {
        private readonly IReceiveLockCommands _remoteControlService;

        public RemoteControlDaemon(IReceiveLockCommands remoteControlService) => _remoteControlService = remoteControlService;

        public IObservable<bool> ShouldLockClient()
        {
            return Observable
                .Interval(TimeSpan.FromSeconds(Settings.Default.SapBackendCallInterval))
                .Select(_ => _remoteControlService.ShouldLockClientAsync())
                .Switch();
        }
    }
}