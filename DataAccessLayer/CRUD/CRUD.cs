using DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using SchoolApi.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CRUD
{
    public class CRUD : ICRUD
    {
        public async Task<T> Create<T>(T entity) where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    await context.AddAsync<T>(entity);
                    await context.SaveChangesAsync();
                    return entity;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete<T>(long entityId) where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    T recordToDelete = await context.FindAsync<T>(entityId);
                    if (recordToDelete != null)
                    {
                        context.Remove(recordToDelete);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> Read<T>(long entityId) where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    T result = await context.FindAsync<T>(entityId);
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<T>> ReadAll<T>() where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Set<T>().ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> Update<T>(T entityToUpdate, long entityId) where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var dataFound = await context.FindAsync<T>(entityId);
                    if (dataFound != null)
                    {
                        context.Entry(dataFound).CurrentValues.SetValues(entityToUpdate);
                        await context.SaveChangesAsync();
                    }
                    return dataFound;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
