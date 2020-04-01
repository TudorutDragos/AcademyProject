using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballProject;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class TeamDAL
    {
        private const string _connectionString = "Server=desktop-491CMSI;Database=Football;Trusted_Connection=True;";
        private const string TEAM_READ_BY_GUID = "dbo.Team_ReadById";
        private const string TEAM_DELETE_BY_GUID = "dbo.Team_DeleteById";
        private const string TEAM_UPDATE_BY_GUID = "dbo.Team_UpdateById";

        public List<Team> ReadAll()
        {
            List<Team> teams = new List<Team>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM dbo.Team";
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Team team = new Team();
                            team = getValues(dataReader);
                            teams.Add(team);
                        }
                    }
                }
            }

            return teams;
        }

        public Team ReadByUid(Guid teamUid)
        {
            Team team = new Team();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = TEAM_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@Team_ID", teamUid));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            team = getValues(dataReader);
                        }
                    }
                }
            }

            return team;
        }

        public void DeleteByUid(Guid teamUid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@Team_ID", teamUid));
                    command.CommandText = TEAM_DELETE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateByUid(Guid teamUid, string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", teamUid));
                    command.Parameters.Add(new SqlParameter("@Name", name));
                    command.CommandText = TEAM_UPDATE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private Team getValues(SqlDataReader dataReader)
        {
            Team team = new Team();
            team.ID = dataReader.GetGuid(dataReader.GetOrdinal("Team_ID"));
            team.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
            team.league = dataReader.GetGuid(dataReader.GetOrdinal("League"));
         
            return team;
        }
    }
}
