using StampCollectorManager.BLL.Interfaces;
using StampCollectorManager.INF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StampCollectorManager.Controllers
{
    public class AdminController : Controller
    {
        private IUnitOfWork unitOfWork = null;

        public AdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public AdminController()
        {

        }

        [HttpGet]
        public JsonResult GetStampCollectors()
        {
            // var stampCollectors = this.unitOfWork.AdminBL.GetAllStampCollectors();
            List<StampCollector> stampCollectors = new List<StampCollector>()
            {
                new StampCollector
                {
                    Id = 1,
                    FirstName = "Karl",
                    LastName = "Zombie",
                    Address = "homeless",
                    Country = "USA",
                    PhoneNumber = "+066666666"
                },
                new StampCollector
                {
                    Id = 2,
                    FirstName = "Omelian",
                    LastName = "Levkovych",
                    Address = "home",
                    Country = "Ukraine",
                    PhoneNumber = "+066666665"
                },
                new StampCollector
                {
                    Id = 3,
                    FirstName = "Ira",
                    LastName = "Seredyuk",
                    Address = "lviv",
                    Country = "Ukraine",
                    PhoneNumber = "+066666664"
                },
                new StampCollector
                {
                    Id = 4,
                    FirstName = "Vova",
                    LastName = "Hnot",
                    Address = "suhiv",
                    Country = "Ukraine",
                    PhoneNumber = "+066666663"
                },
                new StampCollector
                {
                    Id = 5,
                    FirstName = "Roma",
                    LastName = "Malasnyak",
                    Address = "suhiv",
                    Country = "Ukraine",
                    PhoneNumber = "+066666662"

                }
 
            };

            return Json(stampCollectors, JsonRequestBehavior.AllowGet);
        }
    }
}