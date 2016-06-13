using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Voyage.Integration.Application.Interfaces.Repositories;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.Domain
{
    public class QualificationRepository :IQualificationRepository
    {
        public int CreateQualification(QualificationDto qualification, string executingUser)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[CreateQualification]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50)).Value = qualification.Name;
                    command.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar)).Value = qualification.Description;
                    command.Parameters.Add(new SqlParameter("@ExecutingUser", SqlDbType.NVarChar, 50)).Value = executingUser;

                    var response = command.ExecuteNonQuery();
                    return response;
                }
            }
        }

        public int UpdateQualification(QualificationDto qualification, string executingUser)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[UpdateQualification]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@QualificationId", SqlDbType.Int)).Value = qualification.Id;
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50)).Value = qualification.Name;
                    command.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar)).Value = qualification.Description;
                    command.Parameters.Add(new SqlParameter("@ExecutingUser", SqlDbType.NVarChar, 50)).Value = executingUser;
                    

                    var response = command.ExecuteNonQuery();
                    return response;
                }
            }
        }

        public bool DeleteQualification(int qualificationId, string executingUser)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[DeleteQualification]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@QualificationId", SqlDbType.Int)).Value = qualificationId;
                    command.Parameters.Add(new SqlParameter("@ExecutingUser", SqlDbType.NVarChar, 50)).Value = executingUser;

                    var response = command.ExecuteNonQuery();
                    return response > 0;
                }
            }
        }


        public QualificationDto GetQualification(int QualificationId)
        {
            var qualification = new QualificationDto();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[GetQualification]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar, 255)).Value = QualificationId;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            qualification.Name = reader["Name"].ToString();
                            qualification.Description = reader["Description"].ToString();
                        }
                    }
                }
            }

            return qualification;
        }
    }
}
