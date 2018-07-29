using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface ITimeKeeping
    {
        IEnumerable<TimeKeeping> GetAllTimeKeeping();
        bool AddTimeKeeping(TimeKeeping timeKeeping);
        bool UpdateTimeKeeping(TimeKeeping timeKeeping);
        bool DeleteTimeKeeping(int timeKeepingId);
        TimeKeeping FindTimeKeeping(int timeKeepingId);
    }
}
