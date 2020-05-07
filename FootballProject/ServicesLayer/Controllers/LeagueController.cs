using System;
using FootballProject;
using BusniessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicesLayer.Controllers
{
    public class LeagueController : ApiController
    {
        private BLContext _blContext = new BLContext();

        public List<League> GetAll()
        {
            return _blContext.LeagueBL.ReadAll();
        }

        public League GetByUid(League league)
        {
            return _blContext.LeagueBL.ReadByUid(league);
        }

        public void UpdateByUid(League league)
        {
            _blContext.LeagueBL.UpdateByUid(league);
        }

        public void DeleteByUid(League league)
        {
            _blContext.LeagueBL.DeleteByUid(league);
        }
    }
}
