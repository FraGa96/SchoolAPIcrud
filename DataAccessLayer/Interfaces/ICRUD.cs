using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.DataAccessLayer.Interfaces
{
    public interface ICRUD
    {
        Task<T> Create<T>(T entity) where T : class;

        Task<T> Read<T>(Int64 entityId) where T : class;

        Task<List<T>> ReadAll<T>() where T : class;

        Task<T> Update<T>(T entityToUpdate, Int64 entityId) where T : class;

        Task<bool> Delete<T>(Int64 entityId) where T : class;
    }
}
