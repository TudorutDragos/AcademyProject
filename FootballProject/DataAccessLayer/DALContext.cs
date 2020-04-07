using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALContext
    {
        private const string _connectionString = "Server=desktop-491CMSI;Database=Football;Trusted_Connection=True;";
        private ClasamentDAL _clasamentDAL;
        private FootballerDAL _footballerDAL;
        private LeagueDAL _leagueDAL;
        private TeamDAL _teamDAL;
        
        public ClasamentDAL ClasamentDAL
        {
            get
            {
                if(_clasamentDAL == null)
                {
                    _clasamentDAL = new ClasamentDAL(_connectionString);
                }
                return _clasamentDAL;
            }
        }

        public FootballerDAL FootballerDAL
        {
            get
            {
                if (_footballerDAL== null)
                {
                    _footballerDAL= new FootballerDAL(_connectionString);
                }
                return _footballerDAL;
            }
        }

        public LeagueDAL LeagueDAL
        {
            get
            {
                if (_leagueDAL== null)
                {
                    _leagueDAL= new LeagueDAL(_connectionString);
                }
                return _leagueDAL;
            }
        }

        public TeamDAL TeamDAL
        {
            get
            {
                if (_teamDAL== null)
                {
                    _teamDAL = new TeamDAL(_connectionString);
                }
                return _teamDAL;
            }
        }
    }
}
