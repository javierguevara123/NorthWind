﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.Repositories.Interfaces
{
    public interface INorthWindDomainLogsDataContext
    {
        Task AddLogAsync(Entities.DomainLog log);
        Task SaveChangesAsync();
    }

}
