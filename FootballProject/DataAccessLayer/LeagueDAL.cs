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
        private string _connectionString;
        private const string LEAGUE_READ_BY_GUID = "dbo.League_ReadById";
        private const string LEAGUE_DELETE_BY_GUID = "dbo.League_DeleteById";
        private const string LEAGUE_UPDATE_BY_GUID = "dbo.League_UpdateById";
        private const string LEAGUE_READ_ALL = "dbo.League_ReadAll";

        public LeagueDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

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
                    command.CommandText = LEAGUE_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            League league = new League();
                            league = ConverToModel(dataReader);
                            leagues.Add(league);
                        }
                    }
                }
            }

            return leagues;
        }

        public League ReadByUid(League league)
        {
            League newLeague = new League();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = LEAGUE_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@League_ID", league.leagueId));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            newLeague = ConverToModel(dataReader);
                        }
                    }
                }
            }

            return newLeague;
        }

        public void DeleteByUid(League league)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@League_ID", league.leagueId));
                    command.CommandText = LEAGUE_DELETE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateByUid(League league)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", league.leagueId));
                    command.Parameters.Add(new SqlParameter("@Name", league.name));
                    command.CommandText = LEAGUE_UPDATE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private League ConverToModel(SqlDataReader dataReader)
        {
            League league = new League();
            league.leagueId = dataReader.GetGuid(dataReader.GetOrdinal("League_ID"));
            league.name  = dataReader.GetString(dataReader.GetOrdinal("Name"));

            return league;
        }
    }
}
}
