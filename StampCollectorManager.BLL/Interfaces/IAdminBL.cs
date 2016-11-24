using StampCollectorManager.INF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampCollectorManager.BLL.Interfaces
{
    public interface IAdminBL
    {
        IEnumerable<Stamp> GetAllStamps();

        IEnumerable<StampCollector> GetAllStampCollectors();

        Stamp GetStampById(int stampId);

    }
}
