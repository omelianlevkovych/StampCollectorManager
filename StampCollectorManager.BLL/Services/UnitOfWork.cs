using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StampCollectorManager.BLL.Interfaces;

namespace StampCollectorManager.BLL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAdminBL adminBL;

        public UnitOfWork(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        public IAdminBL AdminBL
        {
            get
            {
                return this.adminBL;
            }
        }
    }
}
