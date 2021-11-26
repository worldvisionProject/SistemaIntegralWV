using System;
using WordVision.ec.Application.Interfaces.Shared;

namespace WordVision.ec.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
