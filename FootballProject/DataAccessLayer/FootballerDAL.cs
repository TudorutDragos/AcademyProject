using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballProject;

namespace DataAccessLayer
{
    public class FootballerDAL
    {
        private const string _connectionString = "Server=desktop-491CMSI;Database=Football;Trusted_Connection=True;";
        private const string FOOTBALLER_READ_BY_GUID = "dbo.Footballer_ReadById";
        private const string FOOTBALLER_DELETE_BY_GUID = "dbo.Footballer_DeleteById";
        private const string FOOTBALLER_UPDATE_BY_GUID = "dbo.Footballer_UpdateById";

        public List<Footballer> ReadAll()
        {
            List<Footballer> footballers = new List<Footballer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM dbo.Footballer";
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Footballer footballer = new Footballer();
                            footballer = getValues(dataReader);
                            footballers.Add(footballer);
                        }
                    }
                }
            }

            return footballers;
        }

        public Footballer ReadByUid(Guid footballerUid)
        {
            Footballer footballer = new Footballer();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = FOOTBALLER_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@Footballer_ID", footballerUid));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            footballer = getValues(dataReader);
                        }
                    }
                }
            }

            return footballer;
        }

        public void DeleteByUid(Guid footballerUid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@Footballer_ID", footballerUid));
                    command.CommandText = FOOTBALLER_DELETE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateByUid(Guid footballerUid, string first_name, string last_name, Guid team)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", footballerUid));
                    command.Parameters.Add(new SqlParameter("@First_name", first_name));
                    command.Parameters.Add(new SqlParameter("@Last_name", last_name));
                    command.Parameters.Add(new SqlParameter("@Team", team));
                    command.CommandText = FOOTBALLER_UPDATE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private Footballer getValues(SqlDataReader dataReader)
        {
            Footballer footballer = new Footballer();
            footballer.ID = dataReader.GetGuid(dataReader.GetOrdinal("Footballer_ID"));
            footballer.firstName = dataReader.GetString(dataReader.GetOrdinal("First_Name"));
            footballer.lastName = dataReader.GetString(dataReader.GetOrdinal("Last_Name"));
            footballer.birthDay = dataReader.GetDateTime(dataReader.GetOrdinal("Birth_Day"));
            footballer.nationality = dataReader.GetString(dataReader.GetOrdinal("Nationality"));
            footballer.team = dataReader.GetGuid(dataReader.GetOrdinal("Team"));

            return footballer;
        }
    }
}
