using FootballProject;
using BusniessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServicesLayer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods : "*")]
    public class FootballerController : ApiController
    {
        private BLContext _blContext = new BLContext();

        [HttpGet]
        public List<Footballer> GetAll()
        {
            return _blContext.FootballerBL.ReadAll();
        }

        [HttpGet]
        public Footballer GetByUid(Footballer footballer)
        {
            return _blContext.FootballerBL.ReadByUid(footballer);
        }

        [HttpPost]
        public void Insert(Footballer footballer)
        {
            _blContext.FootballerBL.Insert(footballer);
        }

        [HttpPost]
        public void UpdateByUid(Footballer footballer)
        {
            _blContext.FootballerBL.UpdateByUid(footballer);
        }

        [HttpDelete]
        public void DeleteByUid(Footballer footballer)
        {
            _blContext.FootballerBL.DeleteByUid(footballer);
        }
    }
}
