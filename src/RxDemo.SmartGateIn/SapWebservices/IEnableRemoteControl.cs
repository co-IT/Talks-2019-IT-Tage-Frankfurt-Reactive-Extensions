using System.Threading.Tasks;

namespace SmartGateIn.SapWebservices
{
    public interface IReceiveLockCommands
    {
        Task<bool> ShouldLockClientAsync();
    }
}