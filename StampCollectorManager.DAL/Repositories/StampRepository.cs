
using StampCollectorManager.DAL;
using StampCollectorManager.INF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace StampCollectorManager.DAL.Repositories
{
    public class StampRepository : Interfaces.IRepository<Stamp>
    {
        private ApplicationContext database;

        public StampRepository(ApplicationContext database)
        {
            this.database = database;
            this.database.SaveChanges();
        }

        public IEnumerable<Stamp> GetAll()
        {
            return this.database.Stamps;
        }

        public Stamp Get(object id)
        {
            return this.database.Stamps.Find(id);
        }

        public void Create(Stamp item)
        {
            this.database.Stamps.Add(item);
        }

        public void Update(Stamp item)
        {
            this.database.Entry(item).State = EntityState.Modified;
            this.database.SaveChanges();
        }

        public void Delete(object id)
        {
            Stamp stamp = this.database.Stamps.Find(id);
            if (stamp != null)
            {
                this.database.Stamps.Remove(stamp);
                this.database.SaveChanges();
            }
        }

    }
}
