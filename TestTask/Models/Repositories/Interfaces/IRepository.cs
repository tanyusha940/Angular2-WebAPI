﻿using System.Linq;

namespace TestTask.Models.Repositories.Interfaces
{
    interface IRepository<T> where T: class
    {
        IQueryable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
