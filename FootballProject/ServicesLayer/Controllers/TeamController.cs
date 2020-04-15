using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FootballerProject;
using BusniessLayer;

namespace ServicesLayer.Controllers
{
    public class TeamController : ApiController
    {
        private BLContext _blContext = new BLContext();

        public List<Team> GetAll()
        {
            return _blContext.FootballerBL.ReadAll();
        }

        public Team GetByUid(Team team)
        {
            return _blContext.TeamBL.ReadByUid(team);
        }

        public void UpdateByUid(Team team)
        {
            _blContext.TeamBL.UpdateByUid(team);
        }

        public void DeleteByUid(Team team)
        {
            _blContext.TeamBL.DeleteByUid(team);
        }
    }
}
