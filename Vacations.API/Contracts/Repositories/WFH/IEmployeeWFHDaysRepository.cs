﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities.WFH;

namespace Vacations.API.Contracts.Repositories.WFH
{
    public interface IEmployeeWFHDaysRepository
    {
        Task<IEnumerable<EmployeeWFHDaysEntity>> GetWFHDaysAsync();

    }
}
