using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FootballProject;
namespace DataAccessLayer
{
    public class LeagueDAL
    {
        private const string _connectionString = "Server=desktop-491CMSI;Database=Football;Trusted_Connection=True;";
        private const string LEAGUE_READ_BY_GUID = "dbo.League_ReadById";
        private const string LEAGUE_DELETE_BY_GUID = "dbo.League_DeleteById";
        private const string LEAGUE_UPDATE_BY_GUID = "dbo.League_UpdateById";

        public List<League> ReadAll()
        {
            List<League> leagues = new List<League>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM dbo.League";
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            League league = new League();
                            league = getValues(dataReader);
                            leagues.Add(league);
                        }
                    }
                }
            }

            return leagues;
        }

        public League ReadByUid(Guid leagueUid)
        {
            League league = new League();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = LEAGUE_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@League_ID", leagueUid));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            league = getValues(dataReader);
                        }
                    }
                }
            }

            return league;
        }

        public void DeleteByUid(Guid leagueUid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@League_ID", leagueUid));
                    command.CommandText = LEAGUE_DELETE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateByUid(Guid leagueUid, string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", leagueUid));
                    command.Parameters.Add(new SqlParameter("@Name", name));
                    command.CommandText = LEAGUE_UPDATE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private League getValues(SqlDataReader dataReader)
        {
            League league = new League();
            league.leagueId = dataReader.GetGuid(dataReader.GetOrdinal("League_ID"));
            league.name = dataReader.GetString(dataReader.GetOrdinal("Name"));

            return league;
        }
    }
}
}
