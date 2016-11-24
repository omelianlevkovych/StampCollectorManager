using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StampCollectorManager.INF.EntityFramework;
using StampCollectorManager.BLL.Interfaces;

namespace StampCollectorManager.BLL.Services
{
    public class AdminBL : Interfaces.IAdminBL
    {
        private IDatabaseManager database;

        public AdminBL(IDatabaseManager database)
        {
            this.database = database;
        }

        public IEnumerable<StampCollector> GetAllStampCollectors()
        {
            ICollection<StampCollector> stampCollectors = this.database.StampCollectorManaget.GetAll().ToList();
            return stampCollectors;
        }

        public IEnumerable<Stamp> GetAllStamps()
        {
            ICollection<Stamp> stamps = this.database.StampManager.GetAll().ToList();
            return stamps;
        }

        public Stamp GetStampById(int stampId)
        {
            return this.database.StampManager.Get(stampId);
        }
    }
}
