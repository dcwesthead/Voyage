using System.Threading.Tasks;
using Voyage.Integration.ServiceContracts.Dtos;
using Voyage.Integration.Application.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;

namespace Voyage.Integration.Domain
{
    public class StaffMemberRepository : IStaffMemberRepository
    {
        public int CreateStaffMember(StaffMemberDto staffMember, string executingUser)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[CreateStaffMember]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@Forename", SqlDbType.VarChar, 50)).Value = staffMember.Forename;
                    command.Parameters.Add(new SqlParameter("@Surname", SqlDbType.VarChar, 50)).Value = staffMember.Surname;
                    command.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime)).Value = staffMember.DateOfBirth;
                    command.Parameters.Add(new SqlParameter("@ExecutingUser", SqlDbType.NVarChar, 50)).Value = executingUser;

                    var response = command.ExecuteNonQuery();
                    return response;
                }
            }
        }

        public int UpdateStaffMember(StaffMemberDto staffMember, string executingUser)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[UpdateStaffMember]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@StaffMemberId", SqlDbType.Int)).Value = staffMember.Id;
                    command.Parameters.Add(new SqlParameter("@Forename", SqlDbType.VarChar, 50)).Value = staffMember.Forename;
                    command.Parameters.Add(new SqlParameter("@Surname", SqlDbType.VarChar, 50)).Value = staffMember.Surname;
                    command.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime)).Value = staffMember.DateOfBirth;
                    command.Parameters.Add(new SqlParameter("@ExecutingUser", SqlDbType.NVarChar, 50)).Value = executingUser;


                    var response = command.ExecuteNonQuery();
                    return response;
                }
            }
        }

        public bool DeleteStaffMember(int StaffMemberId, string executingUser)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[DeleteStaffMember]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@StaffMemberId", SqlDbType.Int)).Value = StaffMemberId;
                    command.Parameters.Add(new SqlParameter("@ExecutingUser", SqlDbType.NVarChar, 50)).Value = executingUser;

                    var response = command.ExecuteNonQuery();
                    return response > 0;
                }
            }
        }


        public StaffMemberDto GetStaffMemberName(int StaffMemberId)
        {
            var staffMember = new StaffMemberDto();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("[dbo].[GetStaffMemberName]", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar, 255)).Value = StaffMemberId;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            staffMember.Forename = reader["Forename"].ToString();
                            staffMember.Surname = reader["Surname"].ToString();
                            staffMember.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                        }
                    }
                }
            }

            return staffMember;
        }
    }
}
