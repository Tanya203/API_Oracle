using Oracle.ManagedDataAccess.Client;
using System.ComponentModel.DataAnnotations;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Services
{
    public class ProcedureServices
    {
        public ProcedureServices() { }
        public async Task AutoSchedule(string month)
        {
            using (OracleConnection connection = new OracleConnection("Data Source = localhost:1521 / orcl; User Id = CUOIKY; Password = 12345; Validate Connection = true; "))
            {
                await connection.OpenAsync();

                using (OracleCommand command = connection.CreateCommand())
                {
                    command.CommandText = "ADD_TIME_TABLE_MONTH";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_parameter", OracleDbType.Varchar2).Value = month;

                    await command.ExecuteNonQueryAsync();

                    Console.WriteLine("Success");
                }
            }
        }

    }
}
