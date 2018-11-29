using PES.Data;
using PES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Services
{
    public class WeekDataService
    {
        private readonly Guid _userId;

        public WeekDataService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWeekData(WeekDataCreate model)
        {
            var entity =
                new WeekData()
                {
                    ManagerId = _userId,
                    MondaySales = model.MondaySales,
                    TuesdaySales = model.TuesdaySales,
                    WednesdaySales = model.WednesdaySales,
                    ThursdaySales = model.ThursdaySales,
                    FridaySales = model.FridaySales,
                    SaturdaySales = model.SaturdaySales,
                    SundaySales = model.SundaySales,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.WeekDatas.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WeekDataListItem> GetWeekDatas()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WeekDatas
                        .Where(e => e.ManagerId == _userId)
                        .Select(
                            e =>
                                new WeekDataListItem
                                {
                                    WeekId = e.WeekId,
                                    MondaySales = e.MondaySales,
                                    TuesdaySales = e.TuesdaySales,
                                    WednesdaySales = e.WednesdaySales,
                                    ThursdaySales = e.ThursdaySales,
                                    FridaySales = e.FridaySales,
                                    SaturdaySales = e.SaturdaySales,
                                    SundaySales = e.SundaySales,

                                }
                   );
                return query.ToArray();
            }
        }
    }
}
