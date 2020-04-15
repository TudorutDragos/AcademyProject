using FootballProject;
using BusniessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicesLayer.Controllers
{
    public class FootballerController : ApiController
    {
        private BLContext _blContext = new BLContext();

        public List<Footballer> GetAll()
        {
            return _blContext.FootballerBL.ReadAll();
        }

        public Footballer GetByUid(Footballer footballer)
        {
            return _blContext.FootballerBL.ReadByUid(footballer);
        }

        public void UpdateByUid(Footballer footballer)
        {
            _blContext.FootballerBL.UpdateByUid(footballer);
        }

        public void DeleteByUid(Footballer footballer)
        {
            _blContext.FootballerBL.DeleteByUid(footballer);
        }
    }
}
