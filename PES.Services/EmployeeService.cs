using PES.Data;
using PES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Services
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    ManagerId = _userId,
                    Name = model.Name,
                    AvailableHours = model.AvailableHours,
                    WageAmount = model.WageAmount,
                    Rating = model.Rating,
                    CanOpen = model.CanOpen,
                    CanClose = model.CanClose
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employees
                        .Where(e => e.ManagerId == _userId)
                        .Select(
                            e =>
                                new EmployeeListItem
                                {
                                    EmployeeId = e.EmployeeId,
                                    Name = e.Name,
                                    WageAmount = e.WageAmount,
                                    Rating = e.Rating
                                }
                        );
                return query.ToArray();
            }
        }

        public EmployeeDetail GetEmployeeById(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        .Single(e => e.EmployeeId == employeeId && e.ManagerId == _userId);
                return
                    new EmployeeDetail
                    {
                        EmployeeId = entity.EmployeeId,
                        Name = entity.Name,
                        AvailableHours = entity.AvailableHours,
                        WageAmount = entity.WageAmount,
                        Rating = entity.Rating,
                        CanOpen = entity.CanOpen,
                        CanClose = entity.CanClose
                    };
            }
        }

        public bool UpdateEmployee (EmployeeEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        .Single(e => e.EmployeeId == model.EmployeeId && e.ManagerId == _userId);

                entity.EmployeeId = model.EmployeeId;
                entity.Name = model.Name;
                entity.WageAmount = model.WageAmount;
                entity.CanClose = model.CanClose;
                entity.CanOpen = model.CanOpen;
                entity.AvailableHours = model.AvailableHours;
                entity.Rating = model.Rating;

                return ctx.SaveChanges() == 1; 
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        .Single(e => e.EmployeeId == employeeId && e.ManagerId == _userId);
                ctx.Employees.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
