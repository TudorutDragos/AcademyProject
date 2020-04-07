using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using FootballProject;

namespace BusniessLayer
{
    public class ClasamentBL
    {
        private ClasamentDAL _clasamentDAL;

        public ClasamentBL(ClasamentDAL clasamentDAL)
        {
            _clasamentDAL = clasamentDAL;
        }

        public List<Clasament> ReadAll()
        {
            return _clasamentDAL.ReadAll();
        }

        public Clasament ReadByUid(Clasament clasament)
        {
            return _clasamentDAL.ReadByUid(clasament);
        }

        public void DeleteByUid(Clasament clasament)
        {
            _clasamentDAL.DeleteByUid(clasament);
        }

        public void UpdateByUid(Clasament clasament)
        {
            _clasamentDAL.UpdateByUid(clasament);
        }

    }
}
