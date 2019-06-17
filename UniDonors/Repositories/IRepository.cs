using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniDonors.Models;

namespace UniDonors.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Func<T, bool> predicate);
        bool Any(Func<T, bool> predicate);
        T Edit(T item);
        T Add(T item);
        T Remove(Func<T, bool> predicate);
    }
}
