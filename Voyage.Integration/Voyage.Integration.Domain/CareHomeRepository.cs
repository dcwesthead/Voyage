using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Domain
{
    public class CareHomeRepository : IHomeRepository
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
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[UpdateHome]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@HomeId", SqlDbType.Int)).Value = homeId;
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 255)).Value = homeName;
                    command.Parameters.Add(new SqlParameter("@ExecutingUser", SqlDbType.NVarChar, 50)).Value = executingUser;

                    var response = command.ExecuteNonQuery();
                    return response;
                }
            }
        }

        public bool DeleteHome(int homeId, string executingUser)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[DeleteHome]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@HomeId", SqlDbType.Int)).Value = homeId;
                    command.Parameters.Add(new SqlParameter("@ExecutingUser", SqlDbType.NVarChar, 50)).Value = executingUser;
                    
                    var response = command.ExecuteNonQuery();
                    return response > 0;
                }
            }
        }


        public CareHomeDto GetHome(int homeId)
        {
            var careHomeDto = new CareHomeDto();

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
                            careHomeDto.Id = Convert.ToInt32(reader["Id"].ToString());
                            careHomeDto.Name = reader["Name"].ToString();
                        }
                    }
                }
            }

            return careHomeDto;
        }
    }
}
