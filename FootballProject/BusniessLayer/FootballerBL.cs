using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using FootballProject;

namespace BusniessLayer
{
    public class FootballerBL
    {
        private FootballerDAL _footballerDAL;

        public FootballerBL(FootballerDAL footballerDAL)
        {
            _footballerDAL = footballerDAL;
        }

        public List<Footballer> ReadAll()
        {
            return _footballerDAL.ReadAll();
        }

        public Footballer ReadByUid(Footballer footballer)
        {
            return _footballerDAL.ReadByUid(footballer);
        }

        public void DeleteByUid(Footballer footballer)
        {
            _footballerDAL.DeleteByUid(footballer);
        }

        public void UpdateByUid(Footballer footballer)
        {
            _footballerDAL.UpdateByUid(footballer);
        }        
    }
}
