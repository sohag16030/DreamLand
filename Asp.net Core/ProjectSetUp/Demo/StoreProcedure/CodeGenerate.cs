using TestWeb.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.StoreProcedure
{
    public class CodeGenerate
    {
        DataTable dt = new DataTable();
        public DataTable getCodeGenerate(long AccId, long unitid, long CodegeneratorId)
        {
            try
            {
                using (var connection = new SqlConnection(Connection.erpm_procurement))
                {
                    string sql = "dco.sprCodeGenerate";
                    using (SqlCommand sqlCmd = new SqlCommand(sql, connection))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@AccId", AccId);
                        sqlCmd.Parameters.AddWithValue("@unitid", unitid);
                        sqlCmd.Parameters.AddWithValue("@CodegeneratorId", CodegeneratorId);
                        connection.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdapter.Fill(dt);
                        }
                        connection.Close();
                    }
                }

                return dt;
            }
            catch (Exception)
            {
                return new DataTable();
            }

        }

    }
}
