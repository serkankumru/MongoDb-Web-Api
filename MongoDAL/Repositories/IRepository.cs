﻿using MongoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MongoDAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        bool Insert(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);

        IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> GetAll();

        TEntity GetById(string id);
    }
}