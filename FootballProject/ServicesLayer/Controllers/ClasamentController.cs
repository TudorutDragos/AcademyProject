using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FootballProject;
using BusniessLayer;

namespace ServicesLayer.Controllers
{
    public class ClasamentController : ApiController
    {
        private BLContext _blContext = new BLContext();

        public List<Clasament> GetAll()
        {
            return _blContext.ClasamentBL.ReadAll();
        }

        public Clasament GetByUid(Clasament clasament)
        {
            return _blContext.ClasamentBL.ReadByUid(clasament);
        }

        public void UpdateByUid(Clasament clasament)
        {
            _blContext.ClasamentBL.UpdateByUid(clasament);
        }

        public void DeleteByUid(Clasament clasament)
        {
            _blContext.ClasamentBL.DeleteByUid(clasament);
        }
    }
}
