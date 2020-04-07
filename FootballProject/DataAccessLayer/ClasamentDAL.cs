using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballProject;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    public class ClasamentDAL
    {
        private string _connectionString;
        private const string CLASAMENT_READ_BY_GUID = "dbo.Clasament_ReadById";
        private const string CLASAMENT_DELETE_BY_GUID = "dbo.Clasament_DeleteById";
        private const string CLASAMENT_UPDATE_BY_GUID = "dbo.Clasament_UpdateById";
        private const string CLASAMENT_READ_ALL= "dbo.Clasament_ReadAll";

        public ClasamentDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Clasament> ReadAll()
        {
            List<Clasament> clasaments = new List<Clasament>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = CLASAMENT_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Clasament clasament = new Clasament();
                            clasament = ConvertToModel(dataReader);
                            clasaments.Add(clasament);
                        }
                    }
                }
            }

            return clasaments;
        }

        public Clasament ReadByUid(Clasament clasament)
        {
            Clasament newClasament = new Clasament();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = CLASAMENT_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@Clasament_ID", clasament.clasamentId));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            newClasament = ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return newClasament;
        }

        public void DeleteByUid(Clasament clasament)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@Clasament_ID", clasament.clasamentId));
                    command.CommandText = CLASAMENT_DELETE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateByUid(Clasament clasament)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", clasament.clasamentId));
                    command.Parameters.Add(new SqlParameter("@Position", clasament.position));
                    command.Parameters.Add(new SqlParameter("@Team_Wins", clasament.teamWins));
                    command.Parameters.Add(new SqlParameter("@Team_Defeats", clasament.teamDefeats));
                    command.Parameters.Add(new SqlParameter("@Team_Draws", clasament.teamDraws));
                    command.Parameters.Add(new SqlParameter("@Team_Points", clasament.teamPoints));
                    command.CommandText = CLASAMENT_UPDATE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private Clasament ConvertToModel(SqlDataReader dataReader)
        {
            Clasament clasament = new Clasament();
            clasament.clasamentId = dataReader.GetGuid(dataReader.GetOrdinal("Clasament_ID"));
            clasament.league = dataReader.GetGuid(dataReader.GetOrdinal("League"));
            clasament.position = dataReader.GetInt32(dataReader.GetOrdinal("Position"));
            clasament.teamWins = dataReader.GetInt32(dataReader.GetOrdinal("Team_Wins"));
            clasament.teamDefeats = dataReader.GetInt32(dataReader.GetOrdinal("Team_Defeats"));
            clasament.teamDraws = dataReader.GetInt32(dataReader.GetOrdinal("Team_Draws"));
            clasament.teamPoints = dataReader.GetInt32(dataReader.GetOrdinal("Team_Points"));

            return clasament;
        }
    }
}
