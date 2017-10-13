using Payment.Core.Domain.SystemLogs;
using Payment.Core.Service;
using Payment.Data.DatabaseContext;

namespace Payment.Service.Log
{
    public interface ISystemLogService : IService<LogContext, SystemLog, int>
    {
    }
}
