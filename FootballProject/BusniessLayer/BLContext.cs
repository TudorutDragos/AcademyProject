using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using FootballProject;

namespace BusniessLayer
{
    public class BLContext
    {
        private DALContext _dalContext = new DALContext();
        private FootballerBL _footballerBL;
        private LeagueBL _leagueBL;
        private TeamBL _teamBL;
        private ClasamentBL _clasamentBL;

        public FootballerBL FootballerBL
        {
            get
            {
                if (_footballerBL == null)
                {
                    _footballerBL = new FootballerBL(_dalContext.FootballerDAL);
                }
                return _footballerBL;
            }
        }

        public LeagueBL LeagueBL
        {
            get
            {
                if (_leagueBL == null)
                {
                    _leagueBL = new LeagueBL(_dalContext.LeagueDAL);
                }
                return _leagueBL;
            }
        }

        public TeamBL TeamBL
        {
            get
            {
                if (_teamBL== null)
                {
                    _teamBL= new TeamBL(_dalContext.TeamDAL);
                }
                return _teamBL;
            }
        }

        public ClasamentBL ClasamentBL
        {
            get
            {
                if (_clasamentBL == null)
                {
                    _clasamentBL = new ClasamentBL(_dalContext.ClasamentDAL);
                }
                return _clasamentBL;
            }
        }
    }
}
