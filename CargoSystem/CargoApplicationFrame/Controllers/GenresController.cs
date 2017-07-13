using Cargo.Core.Data.Entity;
using CargoApplicationFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoApplicationFrame.Controllers
{
    public class GenresController : BaseController
    {

        public ActionResult Index()
        {
            GenresEntity entity = new GenresEntity()
            {
                Name="SmallHan",
                Description="test"
            };
            ResponseResult appResult= this.GenresRepository.Add(entity);
            return View();
        }
	}
}