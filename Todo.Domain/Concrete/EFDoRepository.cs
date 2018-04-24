using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Todo.Domain.Abstract;
using Todo.Domain.Entities;
using Todo.Domain.Concrete;
using System.Data.Entity;

namespace Todo.Domain.Concrete
{
    public class EFDoRepository : IDoRepository
    {
        private EFDbContext _context;
        public EFDoRepository(EFDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Do> GetDoList(Statuses? status, Priorities? priority, string option, string search, int page, int pageSize)
        {
            return GetQuery(status, priority, option, search)
                .OrderBy(d => d.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public int TotalCount(Statuses? status, Priorities? priority, string option, string search)
        {
            return GetQuery(status, priority, option, search).Count();

        }
        public bool RemoveFromList(int id)
        {
            try
            {
                var dbDo = GetById(id);

                if (dbDo != null)
                {
                    _context.DO.Remove(dbDo);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Do GetByEvent(string even)
        {
            return _context.DO
                .FirstOrDefault(e => e.Event == even);
        }
        public Do GetById(int id)
        {
            return _context.DO
                 .FirstOrDefault(r => r.Id == id);
        }

        public bool SaveDo(Do result)
        {
            try
            {
                if (result.Id == 0)
                {
                    _context.DO.Add(result);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    _context.Entry(result).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        private IQueryable<Do> GetQuery(Statuses? status, Priorities? priority, string option, string search)
        {
            IQueryable<Do> query = _context.DO
                            .Where(d => status == null || d.Status == status)
                            .Where(d => priority == null || d.Priority == priority);

            if (!string.IsNullOrWhiteSpace(search))
            {
                if (option == "Event")
                {

                    query = query.Where(x => x.Event == search);
                }
                else
                {
                    query = query.Where(x => x.Description.Contains(search));
                }
            }

            return query;
        }
        public bool MultiDelete(IEnumerable<int> ids)
        {
            try
            {
                
                var dos = _context.DO.Where(x => ids.Contains(x.Id)).ToList();
                if (dos != null)
                {
                    _context.DO.RemoveRange(dos);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public bool ChangeStatus(IEnumerable<int> ids, Statuses status)
        {
            try
            {
                var dos = _context.DO.Where(x => ids.Contains(x.Id)).ToList();
                if (dos != null)
                {
                   

                    foreach(var d in dos)
                    {
                        d.Status = status;
                    }
                   
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ChangePriority(IEnumerable<int> ids, Priorities priority)
        {
            try
            {
                var dos = _context.DO.Where(x => ids.Contains(x.Id)).ToList();
                if (dos != null)
                {
                    foreach(var d in dos)
                    {
                        d.Priority = priority;
                    }
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}



