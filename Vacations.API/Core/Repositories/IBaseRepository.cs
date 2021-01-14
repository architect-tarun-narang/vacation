using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities;
using Vacations.API.Models;

namespace Vacations.API.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {

        #region Get Operations

        Task<T> FindEntityContrib(int Id);

        Task<T> FindEntityContrib(string Id);

        Task<IEnumerable<T>> GetEntitiesAsync(string sQuery, object dynamicParameters);
        Task<IEnumerable<T>> GetEntityAsync(string sQuery, int Id);
        Task<IEnumerable<T>> GetEntityAsync(string sQuery);

        Task<IEnumerable<T>> GetAllEntitiesAsync(string sQuery, T obj);

        Task<IEnumerable<T>> GetEntitiesAsync(string sQuery, int[] ids);

        #endregion

        #region Insert Operations
        Task<int> AddEntityContribAsync(T obj);
        Task<int> AddBulkEntitiesAsync(string sQuery, IEnumerable<T> obj);
        Task<int> AddEntitiesAsync(string sQuery, T obj);


        #endregion

        #region Update Operations

        #endregion
        Task<bool> UpdateEntityContribAsync(T obj);
        #region Remove Operations
        Task<bool> DeleteEntityContribAsync(T obj);
        Task DeleteEntitiesAsync(string sQuery, T obj);
        #endregion

       
    }
}
