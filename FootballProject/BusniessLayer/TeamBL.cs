using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using FootballProject;

namespace BusniessLayer
{
    public class TeamBL
    {
        private TeamDAL _teamDAL;

        public TeamBL(TeamDAL teamDAL)
        {
            _teamDAL = teamDAL;
        }

        public List<Team> ReadAll()
        {
            return _teamDAL.ReadAll();
        }

        public Team ReadByUid(Team team)
        {
            return _teamDAL.ReadByUid(team);
        }

        public void DeleteByUid(Team team)
        {
            _teamDAL.DeleteByUid(team);
        }

        public void UpdateByUid(Team team)
        {
            _teamDAL.UpdateByUid(team);
        }

    }
}
