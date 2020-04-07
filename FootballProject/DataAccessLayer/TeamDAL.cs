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
        private string _connectionString;
        private const string TEAM_READ_BY_GUID = "dbo.Team_ReadById";
        private const string TEAM_DELETE_BY_GUID = "dbo.Team_DeleteById";
        private const string TEAM_UPDATE_BY_GUID = "dbo.Team_UpdateById";
        private const string TEAM_READ_ALL= "dbo.Team_ReadAll";

        public TeamDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

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
                    command.CommandText = TEAM_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Team team = new Team();
                            team = ConvertToModel(dataReader);
                            teams.Add(team);
                        }
                    }
                }
            }

            return teams;
        }

        public Team ReadByUid(Team team)
        {
            Team newTeam = new Team();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = TEAM_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@Team_ID", team.ID));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            newTeam = ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return newTeam;
        }

        public void DeleteByUid(Team team)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@Team_ID", team.ID));
                    command.CommandText = TEAM_DELETE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateByUid(Team team)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", team.ID));
                    command.Parameters.Add(new SqlParameter("@Name", team.Name));
                    command.CommandText = TEAM_UPDATE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private Team ConvertToModel(SqlDataReader dataReader)
        {
            Team team = new Team();
            team.ID = dataReader.GetGuid(dataReader.GetOrdinal("Team_ID"));
            team.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
            team.league = dataReader.GetGuid(dataReader.GetOrdinal("League"));
         
            return team;
        }
    }
}
