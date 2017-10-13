using Payment.Core.Data;
using Payment.Core.Domain.SystemLogs;
using Payment.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Log
{
    public class SystemLogService : BaseService<LogContext, SystemLog, int>, ISystemLogService
    {
        public SystemLogService(IRepository<LogContext, SystemLog, int> repository) : base(repository)
        {

        }
    }
}
