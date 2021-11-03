using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public LeaveTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(LeaveType entity)
        {
            _context.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _context.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            var leaveTypes = _context.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _context.LeaveTypes.Find(id);
            return leaveType;
        }

        public ICollection<LeaveType> GetEmplployeeByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exists = _context.LeaveTypes.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _context.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveType entity)
        {
            _context.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
