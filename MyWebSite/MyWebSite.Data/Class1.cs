﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace MyWebSite.Data
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class
    {
        //public RepositoryBase()
        //    : this(new DmsRepositoryContext())
        //{
        //}

        //public RepositoryBase(IRepositoryContext repositoryContext)
        //{
        //    repositoryContext = repositoryContext ?? new DmsRepositoryContext();
        //    _objectSet = repositoryContext.GetObjectSet<T>();
        //}

        private IObjectSet<T> _objectSet;
        public IObjectSet<T> ObjectSet
        {
            get
            {
                return _objectSet;
            }
        }

        #region IRepository Members

        public void Add(T entity)
        {
            this.ObjectSet.AddObject(entity);
        }

        public void Delete(T entity)
        {
            this.ObjectSet.DeleteObject(entity);
        }

        public IList<T> GetAll()
        {
            return this.ObjectSet.ToList<T>();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).ToList<T>();
        }

        public T GetSingle(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).FirstOrDefault<T>();
        }

        public void Attach(T entity)
        {
            this.ObjectSet.Attach(entity);
        }

        public IQueryable<T> GetQueryable()
        {
            return this.ObjectSet.AsQueryable<T>();
        }

        public long Count()
        {
            return this.ObjectSet.LongCount<T>();
        }

        public long Count(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).LongCount<T>();
        }

        #endregion

    }

    public interface IRepository<T>
    {
        //T Create(T objectInstance);
        //void Update(T objectInstance);
        //IList<T> GetAll();
        //IList<T> GetAll(Expression<Func<T, bool>>  expression);
    }
}