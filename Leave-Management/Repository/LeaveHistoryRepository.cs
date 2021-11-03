﻿using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _context;
        public LeaveHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(LeaveHistory entity)
        {
            _context.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _context.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var leaveHistorys=_context.LeaveHistories.ToList();
            return leaveHistorys;
        }

        public LeaveHistory FindById(int id)
        {
            var leaveHistory = _context.LeaveHistories.Find(id);
            return leaveHistory;
        }

        public bool isExists(int id)
        {
            var exists = _context.LeaveHistories.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _context.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _context.LeaveHistories.Update(entity);
            return Save();
        }
    }
}
