using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacations.API.Contexts;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Diagnostics;
using System.Data;

namespace Vacations.API.Core.Repositories
{
    public class BaseRespository<T> : IBaseRepository<T> where T : class
    {
        private IDapperVacationContext _context;

        public BaseRespository(IDapperVacationContext context)
        {
            Debug.WriteLine("Enter.....");
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Get Operations

        public async Task<IEnumerable<T>> GetAllEntitiesAsync(string sQuery, T obj)
        {
            return await _context.WithConnection(async c =>
                 await c.QueryAsync<T>(
                     sQuery,
                     obj,
                     commandType: System.Data.CommandType.Text,
                     commandTimeout: _context.TimeOutPeriod
                  )
              );

            /*            return await _context.WithConnection(async c =>
                        (await c.GetAllAsync<T>()).ToList()
                        ); 
            */
        }


        public async Task<IEnumerable<T>> GetEntityAsync(string sQuery, int Id)
        {
            return await _context.WithConnection(async c =>
                await c.QueryAsync<T>(sQuery,
                 new {Id},
                commandType: CommandType.Text,
                commandTimeout: _context.TimeOutPeriod)
            );

        }

        public async Task<IEnumerable<T>> GetEntityAsync(string sQuery)
        {
            return await _context.WithConnection(async c =>
                await c.QueryAsync<T>(sQuery,
                commandType: CommandType.Text,
                commandTimeout: _context.TimeOutPeriod)
            );

        }



        public async Task<T> FindEntityContrib(int Id)
        {

            using (var connection = _context.SQLConnection)
            {
                return  await connection.GetAsync<T>(Id);
            }
                
        }

        public async Task<T> FindEntityContrib(string Id)
        {

            using (var connection = _context.SQLConnection)
            {
                return await connection.GetAsync<T>(Id);
            }

        }

        public Task<IEnumerable<T>> GetEntitiesAsync(string sql, object dynamicParameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetEntitiesAsync(string sql, int[] ids)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Insert Operations
        public async Task<int> AddBulkEntitiesAsync(string sQuery, IEnumerable<T> obj)
        {
            return await _context.WithConnection(async c => 
                await c.ExecuteAsync(
                    sQuery,
                    obj,
                    commandType: CommandType.Text, 
                    commandTimeout: _context.TimeOutPeriod
                ));

            //return await _context.Connection.ExecuteAsync(sQuery, obj);
        }

        public async Task<int> AddEntityContribAsync(T obj)
        {
            using (var conn = _context.SQLConnection)
            { 
                return await conn.InsertAsync<T>(obj);
            }
        }

        public async Task<bool> UpdateEntityContribAsync(T obj)
        {
            using (var conn = _context.SQLConnection)
            {
                return await conn.UpdateAsync(obj);
            }
        }


            public async Task<int> AddEntitiesAsync(string sQuery, T obj)
        {
            
            return await _context.WithConnection(async c =>
                await c.ExecuteAsync(sQuery,
                 obj,
                commandType: CommandType.Text,
                commandTimeout: _context.TimeOutPeriod)
            );
        }


        #endregion

        #region Update Operations
        
        #endregion

        #region Remove Operations
        public async Task<bool> DeleteEntityContribAsync(T obj)
        {
            using (var conn = _context.SQLConnection)
            {
                return await conn.DeleteAsync<T>(obj);
            }
        }

        public async Task DeleteEntitiesAsync(string sQuery, T obj)
        {
            var scope = _context.Connection.BeginTransaction();
            try
            {
                using (scope)
                {
                    await Task.Run(() =>
                        scope.Connection.ExecuteAsync(sQuery,
                     obj,
                    commandType: CommandType.Text,
                    transaction: scope,
                    commandTimeout: _context.TimeOutPeriod)
                );
                    scope.Commit();
                    //return result;
                }
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw;
            }
            finally 
            {
                _context.Dispose();
            }
        }

        #endregion

    }
}
