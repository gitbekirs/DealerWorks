﻿using DealerWorks.Data.Infrastructure.Entities;
using DealerWorks.Model.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DealerWorks.Data.Infrastructure
{
    public class EntityBaseData<T> : IData<T> where T : ModelBase
    {
        protected readonly DbContext _context;
        public EntityBaseData(DbContext context)
        {
            _context=context;
        }

        public void DetachAllEntities()
        {
            var entries = _context.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Detached)
                .ToList();
            foreach (var entry in entries)
            {
                if (entry.Entity !=null)
                {
                    entry.State = EntityState.Detached;
                }
            }
        }

        protected virtual void BeforeUpdate() { }
        protected virtual void AfterUpdate() { }
        protected virtual void BeforeInsert(T t) { }
        protected virtual void AfterInsert() { }
        protected virtual void BeforeDelete() { }
        protected virtual void AfterDelete() { }


        public DataResult Delete(T t)
        {
            return DeleteByKey(t.Id);
        }

        public DataResult DeleteByKey(int id)
        {
            try
            {
                T aModel = _context.Set<T>().Where(x => x.Id==id).FirstOrDefault();
                if (aModel==null)
                {
                    return new DataResult(false, "Silinecek kayıt bulunamıyor");
                }
                BeforeDelete();
                _context.Set<T>().Remove(aModel);
                AfterDelete();
                _context.SaveChanges();
                return new DataResult(true, "");

            }
            catch (Exception exc)
            {
                return new DataResult(false, exc.Message + exc.InnerException==null ? "" : "("+exc.InnerException+")");

            }
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            try
            {
                var query = _context.Set<T>().AsQueryable();
                if (asNoTracking)
                {
                    query = query.AsNoTracking();
                }
                return query.Where(predicate).Take(1).FirstOrDefault();
            }
            catch (Exception exc)
            {

                return null;
            }
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate, string orderBy = "Id", bool isDesc = false, bool asNoTracking = false)
        {
            try
            {
                var query = _context.Set<T>().AsQueryable();
                if (asNoTracking)
                {
                    query = query.AsNoTracking();
                }
                query = isDesc
                    ? query.OrderByDescending(orderBy)
                    : query.OrderBy(orderBy);

                return query.Where(predicate).Take(1).FirstOrDefault();
            }
            catch (Exception exc)
            {

                return null;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception exc)
            {

                return new List<T>();
            }
        }

        public List<T> GetAll(string orderBy, bool isDesc = false)
        {
            return isDesc
                ? _context.Set<T>().OrderByDescending(orderBy).ToList()
                : _context.Set<T>().OrderBy(orderBy).ToList();
        }

        public List<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>()
                    .Where(predicate)
                    .ToList();
            }
            catch (Exception exc)
            {

                return new List<T>();
            }
        }

        public List<T> GetBy(Expression<Func<T, bool>> predicate, string orderBy, bool isDesc = false)
        {
            try
            {
                return isDesc
               ? _context.Set<T>().Where(predicate).OrderByDescending(orderBy).ToList()
               : _context.Set<T>().Where(predicate).OrderBy(orderBy).ToList();
            }
            catch (Exception exc)
            {
                return new List<T>();
            }
        }

        public T GetByKey(int id)
        {
            try
            {
                T aModel = _context.Set<T>().Where(x => x.Id==id).FirstOrDefault();
                return aModel;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public List<T> GetByPage(int pageNumber, int pageCount, string orderBy = "Id", bool isDesc = false)
        {
            try
            {
                return isDesc
               ? _context.Set<T>().OrderByDescending(orderBy).Skip((pageNumber-1)*pageCount).Take(pageCount).ToList()
               : _context.Set<T>().OrderBy(orderBy).Skip((pageNumber-1)*pageCount).Take(pageCount).ToList();
            }
            catch (Exception exc)
            {
                return new List<T>();
            }
        }

        public List<T> GetByPage(Expression<Func<T, bool>> predicate, int pageNumber, int pageCount, string orderBy = "Id", bool isDesc = false)
        {
            try
            {
                return isDesc
               ? _context.Set<T>().Where(predicate).OrderByDescending(orderBy).Skip((pageNumber-1)*pageCount).Take(pageCount).ToList()
               : _context.Set<T>().Where(predicate).OrderBy(orderBy).Skip((pageNumber-1)*pageCount).Take(pageCount).ToList();
            }
            catch (Exception exc)
            {
                return new List<T>();
            }
        }

        public int GetCount()
        {
            return _context.Set<T>().Select(x => x.Id).Count();
        }

        public int GetCount(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();

        }

        public DataResult Insert(T t)
        {
            try
            {
                BeforeInsert(t);
                _context.Set<T>().Add(t);
                AfterInsert();
                _context.SaveChanges();
                return new DataResult(true, "");
            }
            catch (Exception exc)
            {

                return new DataResult(false, exc.Message + exc.InnerException==null ? "" : "("+exc.InnerException+")");
            }
        }

        public DataResult InsertBulk(List<T> ts, bool validateAndIgnoreBefore = false)
        {
            if (ts.Count<=0)
            {
                return new DataResult(true, "");
            }
            try
            {
                foreach (var t in ts)
                {
                    if (validateAndIgnoreBefore && typeof(IValidatableObject).IsAssignableFrom(t.GetType()))
                    {
                        var results = new List<ValidationResult>();
                        bool isValid = Validator.TryValidateObject(t, new ValidationContext(t, null, null), results, true);
                        if (!isValid)
                        {
                            var resultFirst = results[0];
                            continue;
                        }
                    }
                    _context.Set<T>().Add(t);
                }
                _context.SaveChanges();
                return new DataResult(true, "");
            }
            catch (Exception exc)
            {
                return new DataResult(false, exc.Message + exc.InnerException==null ? "" : "("+exc.InnerException+")");
            }
        }

        public DataResult Update(T t)
        {
            try
            {
                int updateId = t.Id;
                T aModel = _context.Set<T>().Where(x => x.Id==updateId).FirstOrDefault();

                if (aModel==null)
                {
                    return new DataResult(false, "Güncelleme yapılacak kayıt bulunamıyor");
                }

                BeforeUpdate();

                foreach (var propertyInfo in typeof(T).GetProperties())
                {
                    var hasIgnore = Attribute.IsDefined(propertyInfo, typeof(IgnoredAttribute));
                    if (hasIgnore)
                    {
                        continue;
                    }
                    propertyInfo.SetValue(aModel, propertyInfo.GetValue(t, null), null);
                }

                AfterUpdate();
                _context.SaveChanges();
                return new DataResult(true, "");
            }
            catch (Exception exc)
            {
                return new DataResult(false, exc.Message + exc.InnerException==null ? "" : "("+exc.InnerException+")");
            }
        }
    }
}

// dakika 30 da kaldım
//https://youtu.be/bwN2myXHdos?list=PLjn_v5iA99pkZvq4rvp4tM7unhX1dzlU2