using StampCollectorManager.DAL.Interfaces;
using StampCollectorManager.INF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampCollectorManager.BLL.Interfaces
{
    public interface IDatabaseManager
    {
        IRepository<Stamp> StampManager { get; }

        IRepository<StampCollector> StampCollectorManaget { get; }
    }
}
