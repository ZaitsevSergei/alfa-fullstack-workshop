﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Server.Core;

namespace Server.Repository
{
    /// <summary>
    /// Base reasisation Repository for EF
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private SQLContext _context;
        private DbSet<TEntity> _collection;

        public Repository(SQLContext context)
        {
            _context = context;
            _collection = context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _collection.Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeObjects)
        {
            var query = _collection.AsNoTracking();
            return includeObjects
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty))
                .Where(predicate)
                .ToList();
        }

        public void Add(TEntity entity)
        {
            _collection.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _collection.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = _collection.Find(id);

            if (_context.Entry(entityToDelete).State == EntityState.Detached)
                _collection.Attach(entityToDelete);

            _collection.Remove(entityToDelete);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
