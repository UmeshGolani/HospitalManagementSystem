using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data
{
    public class StaffsRepository : IRepository<Staff>
    {
        private readonly HospitalManagementSystemContext _context;

        public StaffsRepository(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        public Staff GetById(int id)
        {
            return _context.Staffs.Find(id);
        }

        public async Task<Staff> GetByIdAsync(int id)
        {
            return await _context.Staffs.FindAsync(id);
        }

        public IEnumerable<Staff> GetAll()
        {
            return _context.Staffs.ToList();
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _context.Staffs.ToListAsync();
        }

        public IEnumerable<Staff> Find(Expression<Func<Staff, bool>> predicate)
        {
            return _context.Staffs.Where(predicate);
        }

        public async Task<IEnumerable<Staff>> FindAsync(Expression<Func<Staff, bool>> predicate)
        {
            return await _context.Staffs.Where(predicate).ToListAsync();
        }

        public Staff SingleOrDefault(Expression<Func<Staff, bool>> predicate)
        {
            return _context.Staffs.SingleOrDefault(predicate);
        }

        public async Task<Staff> SingleOrDefaultAsync(Expression<Func<Staff, bool>> predicate)
        {
            return await _context.Staffs.SingleOrDefaultAsync(predicate);
        }

        public void Add(Staff staff)
        {
            _context.Staffs.Add(staff);
        }

        public void AddRange(IEnumerable<Staff> staffs)
        {
            _context.Staffs.AddRange(staffs);
        }

        public void Remove(Staff staff)
        {
            _context.Staffs.Remove(staff);
        }

        public void RemoveRange(IEnumerable<Staff> staffs)
        {
            _context.Staffs.RemoveRange(staffs);
        }
    }
}
