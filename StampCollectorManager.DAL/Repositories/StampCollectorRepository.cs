using StampCollectorManager.INF.EntityFramework;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampCollectorManager.DAL.Repositories
{
    public class StampCollectorRepository : Interfaces.IRepository<StampCollector>
    {
        private ApplicationContext database;
        
        public StampCollectorRepository(ApplicationContext database)
        {
            this.database = database;
            this.database.SaveChanges();
        }

        public IEnumerable<StampCollector> GetAll()
        {
            return this.database.StampCollectors;
        }

        public StampCollector Get(object id)
        {
            return this.database.StampCollectors.Find(id);
        }

        public void Create(StampCollector item)
        {
            this.database.StampCollectors.Add(item);
            this.database.SaveChanges();
        }

        public void Update(StampCollector item)
        {
            this.database.Entry(item).State = EntityState.Modified;
            this.database.SaveChanges();
        }

        public void Delete(object id)
        {
            StampCollector stampCollector = this.database.StampCollectors.Find(id);
            if (stampCollector != null)
            {
                this.database.StampCollectors.Remove(stampCollector);
                this.database.SaveChanges();
            }
        }

        public StampCollector GetByLastName(string lastName)
        {
            StampCollector stampCollector = this.database.StampCollectors.Where(p => p.LastName == lastName).FirstOrDefault();
            return stampCollector;//this.database.StampCollectors.Where(p => p.LastName == lastName);
        }
    }
}
