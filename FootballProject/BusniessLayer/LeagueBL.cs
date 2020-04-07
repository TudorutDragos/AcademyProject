using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using FootballProject;

namespace BusniessLayer
{
    public class LeagueBL
    {
        private LeagueDAL _leagueDAL;

        public LeagueBL(LeagueDAL leagueDAL)
        {
            _leagueDAL = leagueDAL;
        }

        public List<League> ReadAll()
        {
            return _leagueDAL.ReadAll();
        }

        public League ReadByUid(League league)
        {
            return _leagueDAL.ReadByUid(league);
        }

        public void DeleteByUid(League league)
        {
            _leagueDAL.DeleteByUid(league);
        }

        public void UpdateByUid(League league)
        {
            _leagueDAL.UpdateByUid(league);
        }

    }
}
