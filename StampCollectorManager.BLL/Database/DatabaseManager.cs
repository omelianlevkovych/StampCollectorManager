using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StampCollectorManager.DAL.Interfaces;
using StampCollectorManager.INF.EntityFramework;

namespace StampCollectorManager.BLL.Database
{
    public class DatabaseManager : Interfaces.IDatabaseManager
    {
        private IRepository<Stamp> stampManager;

        private IRepository<StampCollector> stampCollectorManager;

        public DatabaseManager(IRepository<Stamp> stampRepository, IRepository<StampCollector> stampCollectorRepository)
        {
            this.stampManager = stampRepository;
            this.stampCollectorManager = stampCollectorRepository;
        }

        public IRepository<Stamp> StampManager
        {
            get
            {
                return this.stampManager;
            }
        }

        public IRepository<StampCollector> StampCollectorManaget
        {
            get
            {
                return this.stampCollectorManager;
            }
        }
    }
}
