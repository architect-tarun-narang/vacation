using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Filters.EmployeesInformation
{
    public class AllEmployeeInformationResultFilterAttribute: ResultFilterAttribute
    {
        public async override Task OnResultExecutionAsync(ResultExecutingContext context, 
            ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;

            if (resultFromAction?.Value == null ||
                resultFromAction.StatusCode < 200 ||
                resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }


           /* var config = new MapperConfiguration(cfg =>
                cfg.AddProfile<Profiles.EmployeesInformation.EmployeeInformationProfile>()
            );

            var mapper = config.CreateMapper();
            mapper.Map<IEnumerable<Models.EmployeeDTO>>(resultFromAction.Value);*/
            await next();
        }
    }
}
