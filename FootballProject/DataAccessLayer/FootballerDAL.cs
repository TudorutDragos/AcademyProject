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
        private string _connectionString;
        private const string FOOTBALLER_READ_BY_GUID = "dbo.Footballer_ReadById";
        private const string FOOTBALLER_DELETE_BY_GUID = "dbo.Footballer_DeleteById";
        private const string FOOTBALLER_UPDATE_BY_GUID = "dbo.Footballer_UpdateById";
        private const string FOOTBALLER_READ_ALL = "dbo.Footballer_ReadAll";
        private const string FOOTBALLER_INSERT = "dbo.Footballer_Insert";

        public FootballerDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

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
                    command.CommandText = FOOTBALLER_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Footballer footballer = new Footballer();
                            footballer = ConvertToModel(dataReader);
                            footballers.Add(footballer);
                        }
                    }
                }
            }

            return footballers;
        }

        public Footballer ReadByUid(Footballer footballer)
        {
            Footballer newFootballer = new Footballer();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = FOOTBALLER_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@Footballer_ID", footballer.ID));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            newFootballer = ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return newFootballer;
        }

        public void DeleteByUid(Footballer footballer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", footballer.ID));
                    command.CommandText = FOOTBALLER_DELETE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateByUid(Footballer footballer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", footballer.ID));
                    command.Parameters.Add(new SqlParameter("@First_name", footballer.firstName));
                    command.Parameters.Add(new SqlParameter("@Last_name", footballer.lastName));
                    command.Parameters.Add(new SqlParameter("@Team", footballer.team));
                    command.CommandText = FOOTBALLER_UPDATE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Insert(Footballer footballer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@FootballerID", footballer.ID));
                    command.Parameters.Add(new SqlParameter("@FirstName", footballer.firstName));
                    command.Parameters.Add(new SqlParameter("@LastName", footballer.lastName));
                    command.Parameters.Add(new SqlParameter("@BirthDay", footballer.birthDay));
                    command.Parameters.Add(new SqlParameter("@Nationality", footballer.nationality));
                    command.Parameters.Add(new SqlParameter("@Team", footballer.team));
                    command.CommandText = FOOTBALLER_INSERT;

                    command.ExecuteNonQuery();
                }
            }
        }

        private Footballer ConvertToModel(SqlDataReader dataReader)
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
