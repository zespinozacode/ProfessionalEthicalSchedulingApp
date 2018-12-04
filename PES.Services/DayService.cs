using PES.Data;
using PES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Services
{
    public class DayService
    {
        private readonly Guid _userId;

        public DayService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDay(DayCreate model)
        {
            var entity =
                new Day()
                {
                    ManagerId = _userId,
                    DayOfWeek = model.WeekDay,
                    Sales = model.Sales
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Days.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DayListItem> GetDays()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Days
                        .Where(e => e.ManagerId == _userId)
                        .Select(
                        e =>
                            new DayListItem
                            {
                                DayId = e.DayId,
                                WeekDay = e.DayOfWeek,
                                Sales = e.Sales
                            }
                            );
                return query.ToArray();
            }
        }

        public DayDetail GetDayById(int dayId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Days
                        .Single(e => e.DayId == dayId && e.ManagerId == _userId);
                return
                    new DayDetail
                    {
                        DayId = entity.DayId,
                        WeekDay = entity.DayOfWeek,
                        Sales = entity.Sales
                    };
            }
        }

        public bool UpdateDay(DayEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Days
                        .Single(e => e.DayId == model.DayId && e.ManagerId == _userId);

                entity.DayOfWeek = model.WeekDay;
                entity.Sales = model.Sales;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDay(int dayId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Days
                        .Single(e => e.DayId == dayId && e.ManagerId == _userId);

                ctx.Days.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
