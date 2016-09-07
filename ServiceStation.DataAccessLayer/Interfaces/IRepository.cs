﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.DataAccessLayer.Interfaces
{
    interface IRepository<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        IReadOnlyCollection<T> GetAll();
    }
}
