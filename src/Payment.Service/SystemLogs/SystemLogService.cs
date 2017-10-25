using Payment.Data.DatabaseContext;
using Payment.Core.Data;
using Payment.Core.Domain.Log;

namespace Payment.Service.Log
{
    public class SystemLogService : BaseService<LogContext, SystemLog, int>, ISystemLogService
    {
        public SystemLogService(IRepository<LogContext, SystemLog, int> repository) : base(repository)
        {

        }
    }
}
