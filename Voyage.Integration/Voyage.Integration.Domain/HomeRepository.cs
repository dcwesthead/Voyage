using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Voyage.Integration.Application.Interfaces.Repositories;

namespace Voyage.Integration.Domain
{
    public class HomeRepository : IHomeRepository
    {
        public int CreateHome(string homeName, string executingUser)
        {
            using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using(var command = new SqlCommand("[dbo].[CreateHome]", connection) {CommandType = CommandType.StoredProcedure})
                {
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar,255)).Value = homeName;
                    command.Parameters.Add(new SqlParameter("@ExecutingUser", SqlDbType.NVarChar,50)).Value = executingUser;

                    var response = command.ExecuteNonQuery();
                    return response;
                }
            }
        }

        public int UpdateHome(int homeId, string homeName, string executingUser)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHome(int homeId)
        {
            throw new NotImplementedException();
        }


        public string GetHomeName(int homeId)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[GetHomeName]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar, 255)).Value = homeId;

                    using(var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return reader["Name"].ToString();
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
