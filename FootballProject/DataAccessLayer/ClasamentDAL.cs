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
        private const string _connectionString = "Server=desktop-491CMSI;Database=Football;Trusted_Connection=True;";
        private const string CLASAMENT_READ_BY_GUID = "dbo.Clasament_ReadById";
        private const string CLASAMENT_DELETE_BY_GUID = "dbo.Clasament_DeleteById";
        private const string CLASAMENT_UPDATE_BY_GUID = "dbo.Clasament_UpdateById";

        public List<Clasament> ReadAll()
        {
            List<Clasament> clasments = new List<Clasament>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM dbo.Clasament";
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Clasament clasament = new Clasament();
                            clasament = getValues(dataReader);
                            clasments.Add(clasment);
                        }
                    }
                }
            }

            return clasments;
        }

        public Clasament ReadByUid(Guid clasamentUid)
        {
            Clasament clasament = new Clasament();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = CLASAMENT_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@Clasament_ID", clasamentUid));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            clasament = getValues(dataReader);
                        }
                    }
                }
            }

            return clasament;
        }

        public void DeleteByUid(Guid clasamentUid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@Clasament_ID", clasamentUid));
                    command.CommandText = CLASAMENT_DELETE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateByUid(Guid clasamentUid, int position,int teamWins,int teamDefeats,int teamDraws,int teamPoints)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", clasamentUid));
                    command.Parameters.Add(new SqlParameter("@Position", position));
                    command.Parameters.Add(new SqlParameter("@Team_Wins", teamWins));
                    command.Parameters.Add(new SqlParameter("@Team_Defeats", teamDefeats));
                    command.Parameters.Add(new SqlParameter("@Team_Draws", teamDraws));
                    command.Parameters.Add(new SqlParameter("@Team_Points", teamPoints));
                    command.CommandText = CLASAMENT_UPDATE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private Clasament getValues(SqlDataReader dataReader)
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
}
