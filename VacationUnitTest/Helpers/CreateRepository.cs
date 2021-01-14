using System;
using System.Collections.Generic;
using System.Text;
using Vacations.API.Repositories.Employees.Implementations;

namespace VacationUnitTest.Helpers
{
    class CreateRepository
    {
        private readonly EmployeeRepository _vacationRepository;

        public CreateRepository(EmployeeRepository vacationRepository)
        {
            _vacationRepository = vacationRepository ?? throw new ArgumentNullException(nameof(vacationRepository));
        }

        public EmployeeRepository get_vacation_repository()
        {
            return _vacationRepository;
        }
    }
}
