using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        public LeaveAllocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(LeaveAllocation entity)
        {
            _context.leaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _context.leaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var leaveAllocations = _context.leaveAllocations.ToList();
            return leaveAllocations;
        }

        public LeaveAllocation FindById(int id)
        {
            var leaveAllocation = _context.leaveAllocations.Find(id);
            return leaveAllocation;
        }

        public bool isExists(int id)
        {
            var exists = _context.leaveAllocations.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _context.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _context.leaveAllocations.Update(entity);
            return Save();
        }
    }
}
